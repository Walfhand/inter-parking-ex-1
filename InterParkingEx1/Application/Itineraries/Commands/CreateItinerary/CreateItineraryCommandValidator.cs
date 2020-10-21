using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Itineraries.Commands.CreateItinerary
{
    public class CreateItineraryCommandValidator : AbstractValidator<CreateItineraryCommand>
    {
        public CreateItineraryCommandValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty();
            RuleFor(i => i.EndParkingId)
                .NotEmpty();
            RuleFor(i => i.StartParkingId)
                .NotEmpty();
            RuleFor(i => i.CarInformation.CarName)
                .NotEmpty();
            RuleFor(i => i.CarInformation.ConsumptionPer100Km)
                .NotEmpty();
        }
    }
}
