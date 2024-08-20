using Barbershop_Management.Extensions.DataBaseSeeders;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity;
using Bogus;

namespace Barbershop_Management.Extensions
{
    public class DataSeeder
    {
        public static void SeedDatabase(BarbershopDbContext context)
        {
            CreateCustomers(context);
            CreateBarbers(context);
            CreateEnrollments(context);
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
        private static void CreateBarbers(BarbershopDbContext context)
        {
            if (context.Barbers.Any()) return;

            var faker = FakeBarberCreator.Fake();

            for (int i = 0; i < 50; i++)
            {
                var barber = faker.Generate();
                context.Barbers.Add(barber);
            }

            context.SaveChanges();
        }
        private static void CreateEnrollments(BarbershopDbContext context)
        {
            if (context.Enrollments.Any()) return;

            var faker = new Faker();
            var customers = context.Customers.ToArray();
            var barbers = context.Barbers.ToArray();

            for (int i = 0; i < 40; ++i)
            {
                var randomBarber = faker.Random.ArrayElement(barbers);
                var reandomCustomer = faker.Random.ArrayElement(customers);

                decimal initialPay = faker.Random.Decimal(100_000, 200_000);
                decimal totalPrice = faker.Random.Decimal(initialPay * 2, initialPay * 4);

                var enrollment = new Enrollment
                {
                    InitialPayment = initialPay,
                    TotalPrice = totalPrice,
                    CustomerId = reandomCustomer.Id,
                    BarberId = randomBarber.Id,
                    Date = faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now)
                };

                context.Enrollments.Add(enrollment);
            }

            context.SaveChanges();
        }

    }
}
