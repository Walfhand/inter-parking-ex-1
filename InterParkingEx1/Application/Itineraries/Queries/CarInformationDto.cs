using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Itineraries.Queries
{
    public class CarInformationDto
    {
        [DisplayName("Car name")]
        public string CarName { get; set; }
        [DisplayName("Consumption Per 100Km (L)")]
        public double ConsumptionPer100Km { get; set; }
        [DisplayName("Engine start effort (L)")]
        public double EngineStartEffort { get; set; }
    }
}
