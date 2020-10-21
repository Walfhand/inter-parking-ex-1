using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Itineraries.Queries.GetItineraries
{
    public class GetItinerariesQueryHandler : IRequestHandler<GetItinerariesQuery, List<ItineraryDto>>
    {
        private readonly IInterparkingDbContext _context;
        private readonly IMapper _mapper;

        public GetItinerariesQueryHandler(IInterparkingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItineraryDto>> Handle(GetItinerariesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Itineraries
                .Include(i => i.StartParking)
                .Include(i => i.EndParking)
                .Select(i => _mapper.Map<ItineraryDto>(i))
                .ToListAsync();
        }
    }
}
