using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Itineraries.Commands.CreateItinerary;
using Application.Itineraries.Commands.UpdateItinerary;
using Application.Itineraries.Queries.GetItineraries;
using Application.Parkings.Queries.GetParkings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly IMediator _mediator;

        public ItineraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]GetItinerariesQuery query)
        {
            var parkings = await _mediator.Send(new GetParkingsQuery());

            return View(new ItineraryViewModel() 
            {
                Itineraries = await _mediator.Send(query),
                Parkings = parkings.Select(p => new SelectListItem() 
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }).ToList() 
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateItineraryCommand updateItineraryCommand, [FromQuery] GetItinerariesQuery query)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(updateItineraryCommand);
            }

            return RedirectToAction("Index",query);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CreateItineraryCommand createItineraryCommand, [FromQuery] GetItinerariesQuery query)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(createItineraryCommand);
                return RedirectToAction("Index", query);
            }

            return View(new ItineraryViewModel() 
            {
                CreateItineraryCommand = createItineraryCommand,
                Itineraries = await _mediator.Send(query)
            });
        }

        [HttpGet]
        public async Task<IActionResult> Report([FromQuery] GetItinerariesQuery query)
        {
            return View(await _mediator.Send(query));
        }
    }
}
