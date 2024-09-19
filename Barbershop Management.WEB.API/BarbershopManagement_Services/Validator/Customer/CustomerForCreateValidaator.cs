using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Validator.Customer
{
    public class CustomerForCreateValidaator : AbstractValidator<CustomerForCreateDto>
    {
        public CustomerForCreateValidaator() 
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Customer's first name must have at least 5 characters.")
                .MaximumLength(50)
                .WithMessage("Customer's first name must have maximum 50 characters.")
                .Matches(@"^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Customer's first name must consist of letters.");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Customer's first name must have at least 5 characters.")
                .MaximumLength(50)
                .WithMessage("Customer's first name must have maximum 50 characters.")
                .Matches(@"^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Customer's last name must consist of letters."); ;

            RuleFor(customer => customer.PhoneNumber)
               .NotEmpty()
               .WithMessage("Phone number is required.")
               .MinimumLength(13)
               .WithMessage("Phone number's length must have at least 13.")
               .MaximumLength(13)
               .WithMessage("Phone number's length must have maximum 13.")
               .Matches(@"^\+998\d{9}$")
               .WithMessage("Phone number must consist of numbers.");

            RuleFor(customer => customer.Email)
               .NotEmpty()
               .WithMessage("Email is required.")
               .EmailAddress()
               .WithMessage("Email is wrong format.");
        } 
    }
}
