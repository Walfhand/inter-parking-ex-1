using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Queries
{
    public class ParkingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
