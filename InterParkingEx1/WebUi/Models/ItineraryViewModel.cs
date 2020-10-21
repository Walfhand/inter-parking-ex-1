using Application.Itineraries.Commands.CreateItinerary;
using Application.Itineraries.Queries;
using Application.Parkings.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class ItineraryViewModel
    {
        public List<SelectListItem> Parkings { get; set; }
        public List<ItineraryDto> Itineraries { get; set; }
        public CreateItineraryCommand CreateItineraryCommand { get; set; }
    }
}
