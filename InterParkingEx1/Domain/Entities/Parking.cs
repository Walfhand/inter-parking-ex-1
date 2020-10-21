using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Parking()
        {

        }

        public void Update(string name, string address, double latitude, double longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Parking Create(string name, string address,double latitude, double longitude)
        {
            return new Parking()
            {
                Address = address,
                Name = name,
                Latitude = latitude,
                Longitude = longitude
            };
        }
    }
}
