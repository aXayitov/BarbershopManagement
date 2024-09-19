using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Validator.Enrollment
{
    public class EnrollmentForCreateValidator : AbstractValidator<EnrollmentForCreateDto>
    {
        public EnrollmentForCreateValidator(BarbershopDbContext dbContext)
        {
            RuleFor(enrollment => enrollment.Date)
                .NotEmpty()
                .WithMessage("Enrollment date is required.")
                .Must(BeAValidTime)
                .WithMessage("Registration time must be within the current time or the next 7 days.");

            RuleFor(enrollment => enrollment.InitialPayment)
                .GreaterThan(0)
                .WithMessage("Initial payment must be more than 0.");

            RuleFor(enrollment => enrollment.TotalPrice)
                .GreaterThan(50_000)
                .WithMessage("Service price must be more than 50.000 sum.");

            RuleFor(enrollment => enrollment.CustomerId)
                .Custom((customerId, context) =>
                {
                    if (!dbContext.Customers.Any(x => x.Id == customerId))
                    {
                        context.AddFailure($"Customer with {customerId} does not exist.");
                    }
                });

            RuleFor(enrollment => enrollment.BarberId)
                .Custom((barberId, context) =>
                {
                    if (!dbContext.Employees.Any(x => x.Id == barberId))
                    {
                        context.AddFailure($"Barber with {barberId} does not exist.");
                    }
                });
        }
        private bool BeAValidTime(DateTime enrollmentTime)
        {
            return enrollmentTime >= DateTime.Now.AddSeconds(-10) || enrollmentTime <= DateTime.Now.AddDays(7);
        }
    }
}
