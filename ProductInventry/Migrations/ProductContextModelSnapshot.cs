﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProductInventry.Data;
using System;

namespace ProductInventry.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductInventry.Data.Entities.AddOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("AddOrders");
                });

            modelBuilder.Entity("ProductInventry.Data.Entities.AddProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("AddProducts");
                });

            modelBuilder.Entity("ProductInventry.Data.Entities.ListOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("OrderID");

                    b.Property<int>("TotalPrice");

                    b.HasKey("Id");

                    b.ToTable("ListOrders");
                });

            modelBuilder.Entity("ProductInventry.Data.Entities.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("AddOrderId");

                    b.Property<Guid>("AddProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("AddOrderId");

                    b.HasIndex("AddProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("ProductInventry.Data.Entities.OrderProduct", b =>
                {
                    b.HasOne("ProductInventry.Data.Entities.AddOrder", "AddOrder")
                        .WithMany("OrderProducts")
                        .HasForeignKey("AddOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductInventry.Data.Entities.AddProduct", "AddProduct")
                        .WithMany("OrderProducts")
                        .HasForeignKey("AddProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
