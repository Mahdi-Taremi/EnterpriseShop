using Bogus;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Database.Faker
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            CustomInstantiator(f =>
                new Product(
                    $"{f.Commerce.ProductName()} {f.UniqueIndex}",
                    decimal.Parse(f.Commerce.Price(50, 5000)),
                    f.Random.Int(1, 100)));
        }
    }
}