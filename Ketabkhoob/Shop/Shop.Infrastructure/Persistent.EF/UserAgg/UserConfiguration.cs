﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.UserAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");
            builder.HasIndex(b => b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.Email).IsUnique();

            builder.Property(b => b.Email)
                .IsRequired(false)
                .HasMaxLength(256);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(b => b.Name)
                .IsRequired(false)

               .HasMaxLength(80);

            builder.Property(b => b.Family)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsMany(b => b.Addresses, option =>
            {
                option.HasIndex(b => b.UserId);
                option.ToTable("Addresses", "User");

                option.Property(b => b.Province)
                     .IsRequired().HasMaxLength(100);

                option.Property(b => b.City)
                    .IsRequired().HasMaxLength(100);

                option.Property(b => b.Name)
                   .IsRequired().HasMaxLength(50);

                option.Property(b => b.Family)
                    .IsRequired().HasMaxLength(50);


                option.Property(b => b.NationalID)
                    .IsRequired().HasMaxLength(10);

                option.Property(b => b.PostalCode)
                    .IsRequired().HasMaxLength(20);
                option.OwnsOne(b => b.PhoneNumber, config =>
                {
                    config.Property(c=>c.Value)
                    .HasColumnName("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(11);
                });
            });

            builder.OwnsMany(b => b.Wallets, option =>
            {
                option.ToTable("Wallets", "User");
                option.HasIndex(b => b.UserId);

                option.Property(b => b.Description)
                    .IsRequired(false)
                    .HasMaxLength(500);
            });

            builder.OwnsMany(b => b.Roles, option =>
            {
                option.ToTable("Roles", "User");
                option.HasIndex(b => b.UserId);
            });
        }
    }
}
