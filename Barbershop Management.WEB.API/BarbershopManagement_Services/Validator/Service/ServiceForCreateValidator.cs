using BarbershopManagement_Services.DTOs.ServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Validator.Service
{
    public class ServiceForCreateValidator : AbstractValidator<ServiceForCreateDto>
    {
        public ServiceForCreateValidator()
        {
            RuleFor(service => service.Name)
                .NotEmpty().WithMessage("Service name is required")
                .MaximumLength(100)
                .WithMessage("Service name must have maximum 100 characters");

            RuleFor(service => service.Duration)
                .GreaterThan(TimeSpan.FromMinutes(5))
                .WithMessage("Service duration must have minimum 5 minute.")
                .LessThan(TimeSpan.FromHours(5))
                .WithMessage("Service duration must have maximum 5 hours.");

            RuleFor(service => service.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must have positive");
        }
    }
}
