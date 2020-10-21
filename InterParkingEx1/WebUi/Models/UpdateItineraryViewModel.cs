using Application.Itineraries.Commands.UpdateItinerary;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class UpdateItineraryViewModel
    {
        public UpdateItineraryCommand UpdateItineraryCommand { get; set; }
        public List<SelectListItem> Parkings { get; set; }
    }
}
