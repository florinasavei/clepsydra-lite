﻿// <auto-generated />
using ClepsydraLite.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClepsydraLite.DAL.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20200412161347_001AddedShopTable")]
    partial class _001AddedShopTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Shop.ShopCore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops_Core");
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierCore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers_Core");
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierCoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierCoreId");

                    b.ToTable("Suppliers_ProductCategories");
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierProductCategoryId");

                    b.ToTable("Suppliers_ProductOffers");
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductOfferPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PriceType")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierProductOfferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierProductOfferId");

                    b.ToTable("Suppliers_ProductOfferPrices");
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductCategory", b =>
                {
                    b.HasOne("ClepsydraLite.DAL.Entities.Supplier.SupplierCore", "SupplierCore")
                        .WithMany("SupplierProductCategories")
                        .HasForeignKey("SupplierCoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductOffer", b =>
                {
                    b.HasOne("ClepsydraLite.DAL.Entities.Supplier.SupplierProductCategory", "SupplierProductCategory")
                        .WithMany("SupplierProductOffer")
                        .HasForeignKey("SupplierProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClepsydraLite.DAL.Entities.Supplier.SupplierProductOfferPrice", b =>
                {
                    b.HasOne("ClepsydraLite.DAL.Entities.Supplier.SupplierProductOffer", "SupplierProductOffer")
                        .WithMany("SupplierProductPriceOffers")
                        .HasForeignKey("SupplierProductOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
