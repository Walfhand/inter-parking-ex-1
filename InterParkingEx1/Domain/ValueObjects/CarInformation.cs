using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.ValueObjects
{
    [Owned]
    public class CarInformation : ValueObject
    {
        public string CarName { get; set; }
        public double ConsumptionPer100Km { get; set; }
        public double EngineStartEffort { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CarName;
            yield return ConsumptionPer100Km;
            yield return EngineStartEffort;
        }
    }
}
