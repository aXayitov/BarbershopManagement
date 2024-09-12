using BarbershopManagement_Services.DTOs.BarberDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Validator.Barber
{
    public class BarberForCreateValidator : AbstractValidator<BarberForCreateDto>
    {
        public BarberForCreateValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Barber's first name must have at least 5 characters.")
                .MaximumLength(50)
                .WithMessage("Barber's first name must have maximum 50 characters.")
                .Matches(@"^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Barber's first name must consist of letters.");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Barber's first name must have at least 5 characters.")
                .MaximumLength(50)
                .WithMessage("Barber's first name must have maximum 50 characters.")
                .Matches(@"^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Barber's last name must consist of letters."); ;

            RuleFor(customer => customer.PhoneNumber)
               .NotEmpty()
               .WithMessage("Phone number is required.")
               .MinimumLength(13)
               .WithMessage("Phone number's length must have at least 13.")
               .MaximumLength(13)
               .WithMessage("Phone number's length must have maximum 13.")
               .Matches(@"^\+998\d{9}$")
               .WithMessage("Phone number must consist of numbers.");
        }
    }
}
