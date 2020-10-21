using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Parkings.Commands.CreateParking;
using Application.Parkings.Commands.UpdateParking;
using Application.Parkings.Queries;
using Application.Parkings.Queries.GetParkings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IMediator _mediator;

        public ParkingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] GetParkingsQuery query)
        {
            List<ParkingDto> parkings = await _mediator.Send(query);
            return View(new ParkingViewModel() 
            { 
                Parkings = parkings
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateParkingCommand updateParkingCommand, [FromQuery] GetParkingsQuery query)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(updateParkingCommand);
            }

            return RedirectToAction("Index", query);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateParkingCommand createParkingCommand, [FromQuery]GetParkingsQuery query)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(createParkingCommand);
                return RedirectToAction("Index", query);
            }

            return View(new ParkingViewModel() 
            { 
                CreateParkingCommand = createParkingCommand, 
                Parkings =  await _mediator.Send(query)
            });
        }
    }
}
