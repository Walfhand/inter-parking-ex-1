using Application.Parkings.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class ParkingProfile : Profile
    {
        public ParkingProfile()
        {
            CreateMap<ParkingDto, Parking>().ReverseMap();
        }
    }
}
