﻿// <auto-generated />
using System;
using FastFood.DataLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastFood.DataLayer.Migrations
{
    [DbContext(typeof(FastFoodContext))]
    [Migration("20210105200853_fastfood1")]
    partial class fastfood1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CategoryCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CategoryDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CategoryUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("CustomerCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CustomerDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CustomerUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordCustomer")
                        .HasColumnType("int");

                    b.Property<int>("StatusCustomer")
                        .HasColumnType("int");

                    b.Property<int?>("StoreInvoicingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreInvoicingId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfOrders")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProductCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProductDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductPicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProductPreparationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProductUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StoreInvoicingDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("StoreInvoicingDetailsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.StoreInvoicing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("InvoicingDetailId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StoreInvoicingCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StoreInvoicingDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreInvoicingStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StoreInvoicingUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StoreInvoicings");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.StoreInvoicingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("InvoicingDetailCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InvoicingDetailDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoicingDetailStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InvoicingDetailUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoicingId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("LaborCustomerItem")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("StoreInvoicingDetails");
                });

            modelBuilder.Entity("StoreInvoicingStoreInvoicingDetails", b =>
                {
                    b.Property<int>("StoreInvoicingDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("StoreInvoicingsId")
                        .HasColumnType("int");

                    b.HasKey("StoreInvoicingDetailsId", "StoreInvoicingsId");

                    b.HasIndex("StoreInvoicingsId");

                    b.ToTable("StoreInvoicingStoreInvoicingDetails");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Category", b =>
                {
                    b.HasOne("FastFood.DomainClass.Domain.Entities.Products", null)
                        .WithMany("Category")
                        .HasForeignKey("ProductsId");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Customers", b =>
                {
                    b.HasOne("FastFood.DomainClass.Domain.Entities.StoreInvoicing", null)
                        .WithMany("Customers")
                        .HasForeignKey("StoreInvoicingId");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Products", b =>
                {
                    b.HasOne("FastFood.DomainClass.Domain.Entities.StoreInvoicingDetails", null)
                        .WithMany("Products")
                        .HasForeignKey("StoreInvoicingDetailsId");
                });

            modelBuilder.Entity("StoreInvoicingStoreInvoicingDetails", b =>
                {
                    b.HasOne("FastFood.DomainClass.Domain.Entities.StoreInvoicingDetails", null)
                        .WithMany()
                        .HasForeignKey("StoreInvoicingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastFood.DomainClass.Domain.Entities.StoreInvoicing", null)
                        .WithMany()
                        .HasForeignKey("StoreInvoicingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.Products", b =>
                {
                    b.Navigation("Category");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.StoreInvoicing", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("FastFood.DomainClass.Domain.Entities.StoreInvoicingDetails", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}