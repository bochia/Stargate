﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stargate.Server.Data;

#nullable disable

namespace Stargate.Server.Data.Migrations
{
    [DbContext(typeof(StargateContext))]
    partial class StargateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Stargate.Server.Data.Models.AstronautDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CareerEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CareerStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentDutyTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentRank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("AstronautDetail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CareerStartDate = new DateTime(2025, 2, 25, 2, 16, 14, 862, DateTimeKind.Local).AddTicks(8972),
                            CurrentDutyTitle = "Commander",
                            CurrentRank = "1LT",
                            PersonId = 1
                        });
                });

            modelBuilder.Entity("Stargate.Server.Data.Models.AstronautDuty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DutyEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DutyStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DutyTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("AstronautDuty");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DutyStartDate = new DateTime(2025, 2, 25, 2, 16, 14, 862, DateTimeKind.Local).AddTicks(9044),
                            DutyTitle = "Commander",
                            PersonId = 1,
                            Rank = "1LT"
                        });
                });

            modelBuilder.Entity("Stargate.Server.Data.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("Stargate.Server.Data.Models.AstronautDetail", b =>
                {
                    b.HasOne("Stargate.Server.Data.Models.Person", "Person")
                        .WithOne("AstronautDetail")
                        .HasForeignKey("Stargate.Server.Data.Models.AstronautDetail", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Stargate.Server.Data.Models.AstronautDuty", b =>
                {
                    b.HasOne("Stargate.Server.Data.Models.Person", "Person")
                        .WithMany("AstronautDuties")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Stargate.Server.Data.Models.Person", b =>
                {
                    b.Navigation("AstronautDetail");

                    b.Navigation("AstronautDuties");
                });
#pragma warning restore 612, 618
        }
    }
}
