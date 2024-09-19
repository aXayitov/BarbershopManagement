using BarbershopManagement_Services.DTOs.PositionDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Validator.Position
{
    public class PositionForCreateValidator : AbstractValidator<PositionForCreateDto>
    {
        public PositionForCreateValidator()
        {
            RuleFor(position => position.Name)
               .NotEmpty()
               .MinimumLength(5)
               .WithMessage("Position name must have at least 5 characters.")
               .MaximumLength(100)
               .WithMessage("Position name must have maximum 100 characters.")
               .Matches(@"^[a-zA-Zа-яА-Я]+$")
               .WithMessage("Position name must consist of letters.");

            RuleFor(position => position.Description)
                .MinimumLength(5)
                .WithMessage("Position's description must have at least 5 characters.")
                .MaximumLength(255)
                .WithMessage("Position's description must have maximum 100 characters.")
                .Matches(@"^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Position's description must consist of letters.");
        }
    }
}
