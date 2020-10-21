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

namespace Application.Parkings.Queries.GetParkings
{
    public class GetParkingsQueryHandler : IRequestHandler<GetParkingsQuery, List<ParkingDto>>
    {
        private readonly IInterparkingDbContext _interparkingDbContext;
        private readonly IMapper _mapper;

        public GetParkingsQueryHandler(IInterparkingDbContext interparkingDbContext , IMapper mapper)
        {
            _interparkingDbContext = interparkingDbContext;
            _mapper = mapper;
        }

        public async Task<List<ParkingDto>> Handle(GetParkingsQuery request, CancellationToken cancellationToken)
        {
            return await _interparkingDbContext.Parkings
                .Select(p => _mapper.Map<ParkingDto>(p))
                .ToListAsync(cancellationToken);
        }
    }
}
