﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.SellerAgg
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "Seller");
            builder.HasIndex(b => b.NationalCode).IsUnique();

            builder.Property(b => b.NationalCode)
                .IsRequired();

            builder.Property(b => b.ShopName)
                .IsRequired();

            builder.OwnsMany(b => b.Inventories, option =>
            {
                option.ToTable("Inventories", "Seller");
                option.HasIndex(b => b.ProductId);
                option.HasIndex(b => b.SellerId);

            });
        }
    }
}
