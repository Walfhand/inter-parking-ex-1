using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Commands.UpdateParking
{
    public class UpdateParkingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
