using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IGeocodingService
    {
        Task<GeocodingResult> CalculateCoordinates(string address);
        Task<double> CalculateDistanceBeetween2Points(double latPoint1, double lonPoint1, double latPoint2, double lonPoint2);
    }
}
