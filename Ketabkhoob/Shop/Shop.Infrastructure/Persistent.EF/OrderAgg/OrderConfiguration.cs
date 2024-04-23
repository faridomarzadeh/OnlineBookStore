using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Order");

            builder.OwnsOne(b => b.Discount, option=> {
                option.Property(p => p.DiscountTitle).HasMaxLength(50);
            });

            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(p => p.ShippingType).HasMaxLength(50);
            });

            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "Order");
            });

            builder.OwnsOne(b => b.Address, option =>
            {
                option.ToTable("Addresses", "Order");
                option.HasKey(p => p.Id);
                
                option.Property(p=>p.City).HasMaxLength(50)
                .IsRequired();
                option.Property(p => p.Province).HasMaxLength(50);
                option.Property(p => p.PhoneNumber).HasMaxLength(11)
                .IsRequired();
                option.Property(p => p.Family).HasMaxLength(50)
                .IsRequired();
                option.Property(p => p.Name).HasMaxLength(50).IsRequired();
                option.Property(p => p.NationalID).HasMaxLength(11).IsRequired();
                option.Property(p => p.PostalCode).HasMaxLength(30).IsRequired();
                option.Property(p => p.MailingAddress).HasMaxLength(100).IsRequired();

            });
        }
    }
}
