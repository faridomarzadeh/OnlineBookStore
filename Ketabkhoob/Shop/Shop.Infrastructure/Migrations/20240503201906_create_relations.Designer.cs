﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure.Persistent.EF;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20240503201906_create_relations")]
    partial class create_relations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("Shop.Domain.CommentAgg.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Shop.Domain.GeneralEntities.Banner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Shop.Domain.GeneralEntities.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Shop.Domain.OrderAgg.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Orders", "Order");
                });

            modelBuilder.Entity("Shop.Domain.ProductAgg.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(110)
                        .HasColumnType("nvarchar(110)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("SubSubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Products", "Product");
                });

            modelBuilder.Entity("Shop.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "Role");
                });

            modelBuilder.Entity("Shop.Domain.SellerAgg.Seller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("Lastupdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode")
                        .IsUnique();

                    b.ToTable("Sellers", "Seller");
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Family")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users", "User");
                });

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.HasOne("Shop.Domain.CategoryAgg.Category", null)
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("CategoryId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Domain.OrderAgg.Order", b =>
                {
                    b.OwnsOne("Shop.Domain.OrderAgg.OrderAddress", "Address", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("MailingAddress")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalID")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId")
                                .IsUnique();

                            b1.ToTable("Addresses", "Order");

                            b1.WithOwner("Order")
                                .HasForeignKey("OrderId");

                            b1.Navigation("Order");
                        });

                    b.OwnsMany("Shop.Domain.OrderAgg.OrderItem", "Items", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<long>("InventoryId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.HasKey("OrderId", "Id");

                            b1.ToTable("Items", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Shop.Domain.OrderAgg.ValueObjects.OrderDiscount", "Discount", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<int>("DiscountAmount")
                                .HasColumnType("int");

                            b1.Property<string>("DiscountTitle")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Shop.Domain.OrderAgg.ValueObjects.ShippingMethod", "ShippingMethod", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<int>("ShippingCost")
                                .HasColumnType("int");

                            b1.Property<string>("ShippingType")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Discount");

                    b.Navigation("Items");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("Shop.Domain.ProductAgg.Product", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Shop.Domain.ProductAgg.ProductImage", "Images", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("ImageName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<int>("Sequence")
                                .HasColumnType("int");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Images", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Shop.Domain.ProductAgg.ProductSpecification", "Specifications", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Specifications", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Images");

                    b.Navigation("SeoData")
                        .IsRequired();

                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("Shop.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("Shop.Domain.RoleAgg.RolePermission", "Permissions", b1 =>
                        {
                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Permission")
                                .HasColumnType("int");

                            b1.HasKey("RoleId", "Id");

                            b1.ToTable("Permissions", "Role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Shop.Domain.SellerAgg.Seller", b =>
                {
                    b.OwnsMany("Shop.Domain.SellerAgg.SellerInventory", "Inventories", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<int?>("DiscountPercentage")
                                .HasColumnType("int");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("SellerId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.HasIndex("SellerId");

                            b1.ToTable("Inventories", "Seller");

                            b1.WithOwner()
                                .HasForeignKey("SellerId");
                        });

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.OwnsMany("Shop.Domain.UserAgg.UserAddress", "Addresses", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<bool>("IsActive")
                                .HasColumnType("bit");

                            b1.Property<string>("MailingAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalID")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Addresses", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<long>("UserAddressUserId")
                                        .HasColumnType("bigint");

                                    b2.Property<long>("UserAddressId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(11)
                                        .HasColumnType("nvarchar(11)")
                                        .HasColumnName("PhoneNumber");

                                    b2.HasKey("UserAddressUserId", "UserAddressId");

                                    b2.ToTable("Addresses", "User");

                                    b2.WithOwner()
                                        .HasForeignKey("UserAddressUserId", "UserAddressId");
                                });

                            b1.Navigation("PhoneNumber")
                                .IsRequired();
                        });

                    b.OwnsMany("Shop.Domain.UserAgg.UserRole", "Roles", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Roles", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("Shop.Domain.UserAgg.Wallet", "Wallets", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("Description")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<DateTime?>("FinalizedDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsFinalized")
                                .HasColumnType("bit");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<int>("type")
                                .HasColumnType("int");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Wallets", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Roles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
