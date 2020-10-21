using Application.Itineraries.Commands.CreateItinerary;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Itineraries.Commands.UpdateItinerary
{
    public class UpdateItineraryCommandValidator : AbstractValidator<UpdateItineraryCommand>
    {
        public UpdateItineraryCommandValidator()
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
