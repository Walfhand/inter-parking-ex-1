using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Parkings.Commands.CreateParking
{
    public class CreateParkingCommandHandler : IRequestHandler<CreateParkingCommand, int>
    {
        private readonly IInterparkingDbContext _context;
        private readonly IGeocodingService _geocodingService;

        public CreateParkingCommandHandler(IInterparkingDbContext context , IGeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
        }
        public async Task<int> Handle(CreateParkingCommand request, CancellationToken cancellationToken)
        {
            GeocodingResult geocodingResult = await _geocodingService.CalculateCoordinates(request.Address);

            Parking parking = Parking.Create(request.Name, request.Address,geocodingResult.Lat, geocodingResult.Lon);
            _context.Parkings.Add(parking);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
