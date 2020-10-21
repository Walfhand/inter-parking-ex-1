using Application.Itineraries.Queries;
using Application.Parkings.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Itineraries.Commands.CreateItinerary
{
    public class CreateItineraryCommand : IRequest<int>
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Start parking")]
        public int StartParkingId { get; set; }
        [DisplayName("Start parking")]
        public int EndParkingId { get; set; }
        public CarInformationDto CarInformation { get; set; }
    }
}
