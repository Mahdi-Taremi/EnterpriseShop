using Shop.Domain.Entities.Base;
using Shop.Domain.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product : BaseSoftDeleteEntity
    {
        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public int Stock { get; set; }
        private Product()
        {
        }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
        public static Product Create(string name,decimal price,int stock)
        {
            var product = new Product(name, price, stock);

            product.AddDomainEvent(
                new ProductCreatedDomainEvent(product));

            return product;
        }
        public void Update(string name,decimal price,int stock)
        {
            Name = name;

            Price = price;

            Stock = stock;

            AddDomainEvent(
                new ProductUpdatedDomainEvent(this));
        }
        public void Delete()
        {
            AddDomainEvent(
                new ProductDeletedDomainEvent(this));
        }
    }

}
