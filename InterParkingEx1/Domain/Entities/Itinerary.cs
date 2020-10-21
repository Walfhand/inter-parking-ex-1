using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Domain.Entities
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public double FuelNeeded { get; set; }

        public CarInformation CarInformation { get; set; }
        public Parking StartParking { get; set; }
        public Parking EndParking { get; set; }


        public static Itinerary Create(string name, double distance, CarInformation carInformation, Parking startParking, Parking endParking)
        {
            return new Itinerary()
            {
                CarInformation = carInformation,
                StartParking = startParking,
                EndParking = endParking,
                Distance = distance,
                Name = name
            };
        }

        public void Update(string name, double distance, CarInformation carInformation, Parking startParking, Parking endParking)
        {
            CarInformation = carInformation;
            StartParking = startParking;
            EndParking = endParking;
            Distance = distance;
            Name = name;
        }

        public void CalculateFuelNeeded(double distance)
        {
            FuelNeeded = (CarInformation.ConsumptionPer100Km / 100 * distance) + CarInformation.EngineStartEffort;
        }
    }
}
