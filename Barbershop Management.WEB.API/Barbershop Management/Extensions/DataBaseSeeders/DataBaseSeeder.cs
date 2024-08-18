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
            CreateStyle(context);
            CreateCustomers(context);
            CreateBarbers(context);
        }

        private static void CreateStyle(BarbershopDbContext context)
        {
           if (context.Styles.Any()) return;

            var faker = FakeStyleCreator.Fake();

            for(int i = 0; i < 50;  ++i)
            {
                var style = faker.Generate();
                context.Styles.Add(style);
            }

            context.SaveChanges();
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

    }
}
