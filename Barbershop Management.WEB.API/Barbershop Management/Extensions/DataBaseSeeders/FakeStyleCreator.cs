using BarbershopManagement_Domain.Entity;
using Bogus;

namespace Barbershop_Management.Extensions.DataBaseSeeders
{
    public class FakeStyleCreator
    {
        public static Faker<Style> Fake()
        {
            var customerFaker = new Faker<Style>()
                .RuleFor(x => x.Name, (f, u) => f.Vehicle.Model())
                .RuleFor(x => x.Description, (f, u) => f.Vehicle.Model())
                .RuleFor(x => x.Price, (f, u) => f.Random.Decimal(10_000, 100_000))
                .RuleFor(p => p.ExecutionTime, (f, u) => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1)).ToString());

            return customerFaker;
        }
    }
}
