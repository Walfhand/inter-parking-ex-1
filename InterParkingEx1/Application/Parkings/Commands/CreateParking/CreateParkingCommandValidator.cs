using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Commands.CreateParking
{
    public class CreateParkingCommandValidator : AbstractValidator<CreateParkingCommand>
    {
        public CreateParkingCommandValidator()
        {
            RuleFor(p => p.Address)
                .NotEmpty();
            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
