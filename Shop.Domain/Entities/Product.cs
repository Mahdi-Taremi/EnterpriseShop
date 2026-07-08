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
         //AddDomainEvent(new ProductCreatedDomainEvent(Id,Name));
         //AddDomainEvent(new ProductCreatedDomainEvent(this));
        }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            AddDomainEvent(new ProductCreatedDomainEvent(this));

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
