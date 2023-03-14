﻿// <auto-generated />
using System;
using DeliveryApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    [DbContext(typeof(DeliveryContext))]
    [Migration("20230311203239_Add-MenuItemToRestaurant")]
    partial class AddMenuItemToRestaurant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DeliveryApp.Commons.Models.RestaurantAddresses", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("RestaurantAddresses");
                });

            modelBuilder.Entity("DeliveryApp.Commons.Models.UserAddresses", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("PhotosForUser");
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.PhotoForMenuItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MenuItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemsId");

                    b.ToTable("PhotosForMenuItem");
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.PhotoForRestaurant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RestaurantsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("PhotosForRestaurant");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.MenuItems", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrdersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("RestaurantsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.OfferMenuItems", b =>
                {
                    b.Property<Guid>("OfferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfferId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OfferMenuItems");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Offers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateActiveTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReciviedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Restaurants", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "c7fca2c3-76a7-47ea-a497-97f270268fa1",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "f97e79eb-e0e8-4aa5-9828-a0b78a70a0df",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.UserConfigs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserConfigs");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DeliveryApp.Commons.Models.RestaurantAddresses", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Restaurants", null)
                        .WithOne("Address")
                        .HasForeignKey("DeliveryApp.Commons.Models.RestaurantAddresses", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryApp.Commons.Models.UserAddresses", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithOne("UserAddress")
                        .HasForeignKey("DeliveryApp.Commons.Models.UserAddresses", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.Photo", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithMany("Photos")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.PhotoForMenuItem", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.MenuItems", null)
                        .WithMany("Photos")
                        .HasForeignKey("MenuItemsId");
                });

            modelBuilder.Entity("DeliveryApp.ExternalServices.Cloudinary.Photo.PhotoForRestaurant", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Restaurants", null)
                        .WithMany("RestaurantPhotos")
                        .HasForeignKey("RestaurantsId");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.MenuItems", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Orders", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("OrdersId");

                    b.HasOne("DeliveryApp.Repository.Entities.Restaurants", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantsId");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.OfferMenuItems", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.MenuItems", "MenuItem")
                        .WithMany("OfferMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryApp.Repository.Entities.Offers", "Offer")
                        .WithMany("OfferMenuItems")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Orders", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Restaurants", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.HasOne("DeliveryApp.Repository.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.UserConfigs", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithOne("UserConfigs")
                        .HasForeignKey("DeliveryApp.Repository.Entities.UserConfigs", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DeliveryApp.Repository.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.MenuItems", b =>
                {
                    b.Navigation("OfferMenuItems");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Offers", b =>
                {
                    b.Navigation("OfferMenuItems");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Orders", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Restaurants", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("MenuItems");

                    b.Navigation("RestaurantPhotos");
                });

            modelBuilder.Entity("DeliveryApp.Repository.Entities.Users", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("UserAddress");

                    b.Navigation("UserConfigs");
                });
#pragma warning restore 612, 618
        }
    }
}