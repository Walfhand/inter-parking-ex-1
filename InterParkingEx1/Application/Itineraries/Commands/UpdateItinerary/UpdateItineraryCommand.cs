using Application.Itineraries.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Itineraries.Commands.UpdateItinerary
{
    public class UpdateItineraryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Start parking")]
        public int StartParkingId { get; set; }

        [DisplayName("End parking")]
        public int EndParkingId { get; set; }

        public CarInformationDto CarInformation { get; set; }
    }
}
