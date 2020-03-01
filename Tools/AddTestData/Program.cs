using Bogus;
using ForTest.Core;
using ForTest.Core.Data.Enums;
using ForTest.Core.Models;
using System;

namespace AddTestData
{
    class Program
    {

        static void Main(string[] args)
        {
            Faker<Customer> generatorCustomers = getGeneratorCustomers();

            using (var db = new forTestEntities())
            {
                db.Customer.AddRange(generatorCustomers.Generate(750000));
                db.SaveChanges();
            }
        }

        private static Faker<Customer> getGeneratorCustomers()
        {
            return new Faker<Customer>("ru")
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.BirthDay, f => f.Date.Past(40, new DateTime(2000, 1, 1).Date))
                .RuleFor(x => x.Gender, f => f.Random.Enum<ECustomerGender>())
                .RuleFor(x => x.QuantityRequest, f => f.Random.Int(0, 100000));
        }
    }
}
