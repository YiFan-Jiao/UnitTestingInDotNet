﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitTestingInDotNet.Data;

#nullable disable

namespace UnitTestingInDotNet.Migrations
{
    [DbContext(typeof(UnitTestingInDotNetContext))]
    partial class UnitTestingInDotNetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UnitTestingInDotNet.Models.ParkingSpot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ParkingSpot");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Pass", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("Premium")
                        .HasColumnType("bit");

                    b.Property<string>("Purchaser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pass");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingSpotID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParkingSpotID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Vehicle", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<bool>("Parked")
                        .HasColumnType("bit");

                    b.Property<int>("PassID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PassID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Reservation", b =>
                {
                    b.HasOne("UnitTestingInDotNet.Models.ParkingSpot", "ParkingSpot")
                        .WithMany("Reservations")
                        .HasForeignKey("ParkingSpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnitTestingInDotNet.Models.Vehicle", "Vehicle")
                        .WithMany("Reservations")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpot");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Vehicle", b =>
                {
                    b.HasOne("UnitTestingInDotNet.Models.Pass", "Pass")
                        .WithMany("Vehicles")
                        .HasForeignKey("PassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pass");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.ParkingSpot", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Pass", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("UnitTestingInDotNet.Models.Vehicle", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
