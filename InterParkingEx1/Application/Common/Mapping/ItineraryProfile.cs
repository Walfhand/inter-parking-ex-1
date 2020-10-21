using Application.Itineraries.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mapping
{
    public class ItineraryProfile : Profile
    {
        public ItineraryProfile()
        {
            CreateMap<Itinerary, ItineraryDto>().ReverseMap();
        }
    }
}
