using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parkings.Commands.UpdateParking
{
    public class UpdateParkingCommandValidator : AbstractValidator<UpdateParkingCommand>
    {
        public UpdateParkingCommandValidator()
        {
            RuleFor(p => p.Address)
                .NotEmpty();

            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
