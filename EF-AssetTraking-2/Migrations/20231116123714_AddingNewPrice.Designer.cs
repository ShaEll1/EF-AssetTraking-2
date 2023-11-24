﻿// <auto-generated />
using System;
using EF_AssetTraking_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_AssetTraking_2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231116123714_AddingNewPrice")]
    partial class AddingNewPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF_AssetTraking_2.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssetType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetType = "Laptop",
                            Brand = "MacBook",
                            OfficeId = 1,
                            Price = 1500m,
                            PurchaseDate = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AssetType = "Laptop",
                            Brand = "Asus",
                            OfficeId = 2,
                            Price = 1200m,
                            PurchaseDate = new DateTime(2021, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AssetType = "Laptop",
                            Brand = "Lenovo",
                            OfficeId = 1,
                            Price = 1100m,
                            PurchaseDate = new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AssetType = "Laptop",
                            Brand = "MacBook",
                            OfficeId = 3,
                            Price = 1700m,
                            PurchaseDate = new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            AssetType = "Laptop",
                            Brand = "Asus",
                            OfficeId = 3,
                            Price = 900m,
                            PurchaseDate = new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            AssetType = "Mobile Phone",
                            Brand = "Iphone",
                            OfficeId = 2,
                            Price = 800m,
                            PurchaseDate = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            AssetType = "Mobile Phone",
                            Brand = "Samsung",
                            OfficeId = 3,
                            Price = 700m,
                            PurchaseDate = new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            AssetType = "Mobile Phone",
                            Brand = "Nokia",
                            OfficeId = 1,
                            Price = 500m,
                            PurchaseDate = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            AssetType = "Mobile Phone",
                            Brand = "Iphone",
                            OfficeId = 1,
                            Price = 1000m,
                            PurchaseDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            AssetType = "Mobile Phone",
                            Brand = "Iphone",
                            OfficeId = 3,
                            Price = 900m,
                            PurchaseDate = new DateTime(2021, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EF_AssetTraking_2.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("EF_AssetTraking_2.Asset", b =>
                {
                    b.HasOne("EF_AssetTraking_2.Office", "Office")
                        .WithMany("Asset")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("EF_AssetTraking_2.Office", b =>
                {
                    b.Navigation("Asset");
                });
#pragma warning restore 612, 618
        }
    }
}
