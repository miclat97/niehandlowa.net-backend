﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using niehandlowa.net.Dal;

namespace niehandlowa.net.Dal.Migrations
{
    [DbContext(typeof(NonTradeContext))]
    [Migration("20180615170214_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("niehandlowa.net.Dal.Entities.OpeningHoursEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ClosingTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<DateTime>("OpeningTime");

                    b.Property<int>("POIId");

                    b.HasKey("Id");

                    b.HasIndex("POIId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("niehandlowa.net.Dal.Entities.POIEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("DislikesCount");

                    b.Property<double>("Latitude");

                    b.Property<int>("LikesCount");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("POIEntities");
                });

            modelBuilder.Entity("niehandlowa.net.Dal.Entities.OpeningHoursEntity", b =>
                {
                    b.HasOne("niehandlowa.net.Dal.Entities.POIEntity", "POI")
                        .WithMany("OpeningHours")
                        .HasForeignKey("POIId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
