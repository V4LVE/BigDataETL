﻿// <auto-generated />
using System;
using BigDataETL.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigDataETL.Repository.Migrations
{
    [DbContext(typeof(BigDataContext))]
    [Migration("20240513063100_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigDataETL.Repository.Entites.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightID"));

                    b.Property<double?>("Baro_altitude")
                        .HasColumnType("float");

                    b.Property<string>("Callsign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Geo_altitude")
                        .HasColumnType("float");

                    b.Property<string>("Icao24")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Last_contact")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<bool?>("On_ground")
                        .HasColumnType("bit");

                    b.Property<string>("Origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Position_source")
                        .HasColumnType("int");

                    b.Property<string>("Sensors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Spi")
                        .HasColumnType("bit");

                    b.Property<string>("Squawk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Time_position")
                        .HasColumnType("int");

                    b.Property<double?>("True_track")
                        .HasColumnType("float");

                    b.Property<double?>("Velocity")
                        .HasColumnType("float");

                    b.Property<double?>("Vertical_rate")
                        .HasColumnType("float");

                    b.HasKey("FlightID");

                    b.ToTable("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}