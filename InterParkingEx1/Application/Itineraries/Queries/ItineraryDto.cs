using Application.Parkings.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Itineraries.Queries
{
    public class ItineraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public double FuelNeeded { get; set; }

        public CarInformationDto CarInformation { get; set; }
        public ParkingDto StartParking { get; set; }
        public ParkingDto EndParking { get; set; }
    }
}
