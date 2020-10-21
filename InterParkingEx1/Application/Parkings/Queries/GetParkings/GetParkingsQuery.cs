using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Queries.GetParkings
{
    public class GetParkingsQuery : IRequest<List<ParkingDto>>
    {
    }
}
