using Application.Parkings.Commands.CreateParking;
using Application.Parkings.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class ParkingViewModel
    {
        public List<ParkingDto> Parkings { get; set; }
        public CreateParkingCommand CreateParkingCommand { get; set; }
    }
}
