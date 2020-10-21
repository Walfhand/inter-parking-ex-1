using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Itineraries.Commands.UpdateItinerary
{
    public class UpdateItineraryCommandHandler : IRequestHandler<UpdateItineraryCommand, int>
    {
        private readonly IInterparkingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGeocodingService _geocodingService;

        public UpdateItineraryCommandHandler(IInterparkingDbContext context, IMapper mapper, IGeocodingService geocodingService)
        {
            _context = context;
            _mapper = mapper;
            _geocodingService = geocodingService;
        }

        public async Task<int> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            Itinerary itinerary = await _context.Itineraries.FindAsync(request.Id);
            Parking startParking = await _context.Parkings.FindAsync(request.StartParkingId);
            Parking endParking = await _context.Parkings.FindAsync(request.EndParkingId);

            if (itinerary == null || startParking == null || endParking == null)
            {
                return 0;
            }

            double distance = await _geocodingService.CalculateDistanceBeetween2Points(startParking.Latitude, startParking.Longitude, endParking.Latitude, endParking.Longitude);

            itinerary.Update(request.Name, distance ,_mapper.Map<CarInformation>(request.CarInformation),startParking, endParking);
            itinerary.CalculateFuelNeeded(distance);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
