using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Itineraries.Queries.GetItineraries
{
    public class GetItinerariesQuery : IRequest<List<ItineraryDto>>
    {
    }
}
