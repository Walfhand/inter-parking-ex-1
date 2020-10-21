using Application.Itineraries.Queries;
using AutoMapper;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mapping
{
    public class CarInformationProfile : Profile
    {
        public CarInformationProfile()
        {
            CreateMap<CarInformation, CarInformationDto>()
                .ReverseMap();
        }
    }
}
