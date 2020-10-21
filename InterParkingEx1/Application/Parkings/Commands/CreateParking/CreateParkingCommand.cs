using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Commands.CreateParking
{
    public class CreateParkingCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
