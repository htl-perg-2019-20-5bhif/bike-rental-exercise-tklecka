﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bike_rental_exercise_tklecka.Data;

namespace bike_rental_exercise_tklecka.Migrations
{
    [DbContext(typeof(BikeDataContext))]
    [Migration("20191119161556_fix-07")]
    partial class fix07
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bike_rental_exercise_tklecka.Model.Bike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeCategory")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("DateService")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<double>("PriceAddHour")
                        .HasColumnType("float");

                    b.Property<double>("PriceHour")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("bike_rental_exercise_tklecka.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<int>("ZIP")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("bike_rental_exercise_tklecka.Model.Rental", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("PaidFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RentalBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalEnd")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BikeID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("bike_rental_exercise_tklecka.Model.Rental", b =>
                {
                    b.HasOne("bike_rental_exercise_tklecka.Model.Bike", "Bike")
                        .WithMany()
                        .HasForeignKey("BikeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bike_rental_exercise_tklecka.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
