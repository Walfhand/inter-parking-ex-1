using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Parkings.Commands.UpdateParking
{
    public class UpdateParkingCommandHandler : IRequestHandler<UpdateParkingCommand, int>
    {
        private readonly IInterparkingDbContext _context;
        private readonly IGeocodingService _geocodingService;

        public UpdateParkingCommandHandler(IInterparkingDbContext context, IGeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
        }
        public async Task<int> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
        {
            Parking parking = await _context.Parkings.FindAsync(request.Id);

            if(parking != null)
            {
                GeocodingResult geocodingResult = await _geocodingService.CalculateCoordinates(request.Address);
                parking.Update(request.Name, request.Address,geocodingResult.Lat, geocodingResult.Lon);
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
