using Barbershop_Management.Extensions.DataBaseSeeders;
using BarbershopManagemen_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BarbershopManagement_Domain.Entity;
using Bogus;

namespace Barbershop_Management.Extensions
{
    public class DataSeeder
    {
        public static void SeedDatabase(BarbershopDbContext context)
        {
            CreateCustomers(context);
            CreateEmployee(context);
            CreateEnrollments(context);
            CreatePayments(context);
        }

        private static void CreateCustomers(BarbershopDbContext context)
        {
            if (context.Customers.Any()) return;

            var faker = FakeCustomerCreator.Fake();

            for (int i = 0; i < 50; i++)
            {
                var customer = faker.Generate();
                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }
        private static void CreateEmployee(BarbershopDbContext context)
        {
            if (context.Employees.Any()) return;

            var faker = new Faker();
            var positions = context.Positions.ToArray();

            var employeeFaker = FakeEmployeeCreator.Fake();

            for (int i = 0; i < 50; i++)
            {
                var position = faker.Random.ArrayElement(positions);

                var barber = employeeFaker.Generate();
                barber.Position = position;

                context.Employees.Add(barber);
            }

            context.SaveChanges();
        }
        private static void CreateEnrollments(BarbershopDbContext context)
        {
            if (context.Enrollments.Any()) return;

            var faker = new Faker();
            var customers = context.Customers.ToArray();
            var barbers = context.Employees.ToArray();
            var services = context.Services.ToArray();

            for (int i = 0; i < 40; ++i)
            {
                var randomBarber = faker.Random.ArrayElement(barbers);
                var reandomCustomer = faker.Random.ArrayElement(customers);
                var randomService = faker.Random.ArrayElement(services);

                var enrollment = new Enrollment
                {
                    CustomerId = reandomCustomer.Id,
                    EmployeeId = randomBarber.Id,
                    ServiceId = randomService.Id,
                    Date = faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now)
                };

                context.Enrollments.Add(enrollment);
            }

            context.SaveChanges();
        }

        private static void CreatePayments(BarbershopDbContext context)
        {
            if(context.Payments.Any()) return;

            var faker = new Faker();
            var enrollments = context.Enrollments.Include(x => x.Service).ToArray();
            int enrollmentsCount = enrollments.Length;

            for(int i = 0; i < enrollmentsCount; ++i)
            {
                var payment = new Payment
                {
                    EnrollmentId = enrollments[i].Id,
                    Amount = enrollments[i].Service.Price,
                    PaymentDate = enrollments[i].Date,
                    PaymentType = faker.Random.Enum<PaymentMethod>()
                };

                context.Payments.Add(payment);
            }

            context.SaveChanges();
        }

    }
}
