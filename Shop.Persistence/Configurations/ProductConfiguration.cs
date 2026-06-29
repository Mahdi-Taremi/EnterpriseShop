using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Price)
                .HasPrecision(10, 2);
            builder.Property(x => x.Stock)
                .HasDefaultValue(0);
            builder.Property(x => x.IsDeleted)
                 .HasDefaultValue(false);
            builder.Property(x => x.RowVersion)
                 .IsRowVersion();
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(

            new Product
            {
                 Name = "Keyboard",
                 Price = 150,
                 Stock = 5
            });
        }
    }
}
