﻿using BarbershopManagement_Domain.Entity;
using Bogus;

namespace Barbershop_Management.Extensions.DataBaseSeeders
{
    public class FakeBarberCreator
    {
        public static Faker<Barber> Fake()
        {
            var customerFaker = new Faker<Barber>()
                .RuleFor(x => x.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(x => x.LastName, (f, u) => f.Name.LastName())
                .RuleFor(x => x.PhoneNumber, (f, u) => f.Phone.PhoneNumber("+998#########"));

            return customerFaker;
        }
    }
}
