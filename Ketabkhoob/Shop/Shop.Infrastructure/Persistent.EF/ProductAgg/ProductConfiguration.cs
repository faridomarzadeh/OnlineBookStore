using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.EF.ProductAgg
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Product");
            builder.HasIndex(b=>b.Slug).IsUnique();
            builder.Property(b=>b.Title).IsRequired()
                .HasMaxLength(150);
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.ImageName).IsRequired().HasMaxLength(110);
            builder.Property(b=>b.Slug).IsRequired().IsUnicode(false);
            builder.OwnsOne(b => b.SeoData, config =>
            {
                config.Property(p => p.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("MetaDescription");

                config.Property(r => r.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("MetaTitle");

                config.Property(r => r.MetaKeyWords)
                .HasMaxLength(500)
                .HasColumnName("MetaKeyWords");

                config.Property(t => t.IndexPage)
                .HasColumnName("IndexPage");

                config.Property(u => u.Canonical)
                .HasColumnName("Canonical");

                config.Property(r => r.Schema)
                .HasColumnName("Schema");
            });

            builder.OwnsMany(b => b.Images, config =>
            {
                config.ToTable("Images", "Product");
                config.Property(f => f.ImageName)
                .IsRequired()
                .HasMaxLength(100);
            });

            builder.OwnsMany(b => b.Specifications, config =>
            {
                config.ToTable("Specifications", "Product");

                config.Property(r=>r.Key)
                .IsRequired()
                .HasMaxLength(50);

                config.Property(r => r.Value)
                .IsRequired()
                .HasMaxLength(100);

            });
        }
    }
}
