﻿// <auto-generated />
using System;
using BuberDinner.Infrashstructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuberDinner.Infrashstructure.Migrations
{
    [DbContext(typeof(BuberDinnerDbContext))]
    partial class BuberDinnerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BuberDinner.Domain.DinnerAggregate.Dinner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EndedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MaxGuest")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("StartedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Dinners", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.MenuAggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.DinnerAggregate.Dinner", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.BillAggregate.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsMany("BuberDinner.Domain.DinnerAggregate.Entities.Reservation", "Reservations", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime?>("ArrivalDateTime")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("BillId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("datetime(6)");

                            b1.Property<int>("GuestCount")
                                .HasColumnType("int");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ReservationStatus")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("DinnerId", "Id");

                            b1.ToTable("Reservations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsOne("BuberDinner.Domain.DinnerAggregate.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BuberDinner.Domain.MenuAggregate.Menu", b =>
                {
                    b.OwnsMany("BuberDinner.Domain.DinnerAggregate.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("MenuDinnerId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuDinnerId");

                            b1.ToTable("MenuDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuDinnerId");
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("double");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.MenuAggregate.Entities.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)")
                                .HasColumnName("MenuSectionId");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("BuberDinner.Domain.MenuAggregate.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("char(36)")
                                        .HasColumnName("MenuItemId");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuSectionId", "MenuId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuSectionId", "MenuId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsMany("BuberDinner.Domain.MenuReviewAggregate.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("ReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
