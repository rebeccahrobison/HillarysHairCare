﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    [DbContext(typeof(HillarysHairCareDbContext))]
    [Migration("20240104193534_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApptTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApptTime = new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            StylistId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApptTime = new DateTime(2024, 1, 16, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            StylistId = 2
                        },
                        new
                        {
                            Id = 3,
                            ApptTime = new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            StylistId = 3
                        },
                        new
                        {
                            Id = 4,
                            ApptTime = new DateTime(2024, 1, 17, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 4,
                            StylistId = 4
                        },
                        new
                        {
                            Id = 5,
                            ApptTime = new DateTime(2024, 1, 5, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 5,
                            StylistId = 5
                        },
                        new
                        {
                            Id = 6,
                            ApptTime = new DateTime(2024, 1, 6, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 6,
                            StylistId = 6
                        },
                        new
                        {
                            Id = 7,
                            ApptTime = new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 7,
                            StylistId = 7
                        },
                        new
                        {
                            Id = 8,
                            ApptTime = new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 8,
                            StylistId = 8
                        },
                        new
                        {
                            Id = 9,
                            ApptTime = new DateTime(2024, 1, 11, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 9,
                            StylistId = 9
                        },
                        new
                        {
                            Id = 10,
                            ApptTime = new DateTime(2024, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 10,
                            StylistId = 10
                        },
                        new
                        {
                            Id = 11,
                            ApptTime = new DateTime(2023, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 10,
                            StylistId = 9
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 3,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 6,
                            AppointmentId = 3,
                            ServiceId = 6
                        },
                        new
                        {
                            Id = 7,
                            AppointmentId = 4,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 8,
                            AppointmentId = 5,
                            ServiceId = 8
                        },
                        new
                        {
                            Id = 9,
                            AppointmentId = 5,
                            ServiceId = 9
                        },
                        new
                        {
                            Id = 10,
                            AppointmentId = 6,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 11,
                            AppointmentId = 7,
                            ServiceId = 8
                        },
                        new
                        {
                            Id = 12,
                            AppointmentId = 7,
                            ServiceId = 9
                        },
                        new
                        {
                            Id = 13,
                            AppointmentId = 7,
                            ServiceId = 10
                        },
                        new
                        {
                            Id = 14,
                            AppointmentId = 8,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 15,
                            AppointmentId = 8,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 16,
                            AppointmentId = 9,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 17,
                            AppointmentId = 9,
                            ServiceId = 5
                        },
                        new
                        {
                            Id = 18,
                            AppointmentId = 10,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 19,
                            AppointmentId = 10,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 20,
                            AppointmentId = 11,
                            ServiceId = 7
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "verac@gmail.com",
                            Name = "Vera Carter"
                        },
                        new
                        {
                            Id = 2,
                            Email = "liamj@gmail.com",
                            Name = "Liam Johnson"
                        },
                        new
                        {
                            Id = 3,
                            Email = "avad@gmail.com",
                            Name = "Ava Davis"
                        },
                        new
                        {
                            Id = 4,
                            Email = "noahm@gmail.com",
                            Name = "Noah Miller"
                        },
                        new
                        {
                            Id = 5,
                            Email = "oliviaw@gmail.com",
                            Name = "Olivia Wilson"
                        },
                        new
                        {
                            Id = 6,
                            Email = "emmat@gmail.com",
                            Name = "Emma Thompson"
                        },
                        new
                        {
                            Id = 7,
                            Email = "jacksona@gmail.com",
                            Name = "Jackson Anderson"
                        },
                        new
                        {
                            Id = 8,
                            Email = "sophiaw@gmail.com",
                            Name = "Sophia White"
                        },
                        new
                        {
                            Id = 9,
                            Email = "lucasm@gmail.com",
                            Name = "Lucas Martinez"
                        },
                        new
                        {
                            Id = 10,
                            Email = "isabellag@gmail.com",
                            Name = "Isabella Garcia"
                        },
                        new
                        {
                            Id = 11,
                            Email = "aidens@gmail.com",
                            Name = "Aiden Smith"
                        },
                        new
                        {
                            Id = 12,
                            Email = "miat@gmail.com",
                            Name = "Mia Taylor"
                        },
                        new
                        {
                            Id = 13,
                            Email = "calebb@gmail.com",
                            Name = "Caleb Brown"
                        },
                        new
                        {
                            Id = 14,
                            Email = "ellaj@gmail.com",
                            Name = "Ella Jones"
                        },
                        new
                        {
                            Id = 15,
                            Email = "loganm@gmail.com",
                            Name = "Logan Moore"
                        },
                        new
                        {
                            Id = 16,
                            Email = "averyh@gmail.com",
                            Name = "Avery Hall"
                        },
                        new
                        {
                            Id = 17,
                            Email = "harpert@gmail.com",
                            Name = "Harper Thomas"
                        },
                        new
                        {
                            Id = 18,
                            Email = "benjaminh@gmail.com",
                            Name = "Benjamin Harris"
                        },
                        new
                        {
                            Id = 19,
                            Email = "ameliaa@gmail.com",
                            Name = "Amelia Adams"
                        },
                        new
                        {
                            Id = 20,
                            Email = "elijahc@gmail.com",
                            Name = "Elijah Clark"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cut",
                            Price = 50.00m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Color",
                            Price = 80.00m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Highlights",
                            Price = 100.00m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Blowout",
                            Price = 35.00m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Perm",
                            Price = 70.00m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Updo",
                            Price = 60.00m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Extensions",
                            Price = 120.00m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Manicure",
                            Price = 25.00m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Pedicure",
                            Price = 35.00m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Facial",
                            Price = 45.00m
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Name = "Janet Brown"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Name = "Emily Taylor"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Name = "Michael Black"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Name = "Sophie Harris"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Name = "David Wu"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            Name = "Olivia Rodriguez"
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            Name = "Daniel Johnson"
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            Name = "Mia Verrt"
                        },
                        new
                        {
                            Id = 9,
                            Active = false,
                            Name = "Andrew Wilson"
                        },
                        new
                        {
                            Id = 10,
                            Active = false,
                            Name = "Emma Martinez"
                        });
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHairCare.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Service", b =>
                {
                    b.HasOne("HillarysHairCare.Models.Appointment", null)
                        .WithMany("Services")
                        .HasForeignKey("AppointmentId");
                });

            modelBuilder.Entity("HillarysHairCare.Models.Appointment", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}