using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.Cloudinary.Photo;
using DeliveryApp.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Context
{

    public class DeliveryContext : IdentityDbContext<Entities.Users, Roles, int>
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
        }

        public DbSet<Offers> Offers { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<OfferMenuItems> OfferMenuItems { get; set; }
        public DbSet<PhotoForMenuItem> PhotosForMenuItem { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<RestaurantAddresses> RestaurantAddresses { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<Photo> PhotosForUser { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<UserConfigs> UserConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OfferMenuItems>()
                .HasKey(x => new { x.offerId, x.menuItemId });
            builder.Entity<OfferMenuItems>().HasOne(offer => offer.offer)
                .WithMany(om => om.offerMenuItems)
                .HasForeignKey(id => id.offerId);
            builder.Entity<OfferMenuItems>().HasOne(menuItem => menuItem.menuItem)
            .WithMany(om => om.offerMenuItems)
                .HasForeignKey(id => id.menuItemId);
            builder.Entity<RestaurantAddresses>().HasKey(x => x.addressId);
            builder.Entity<Restaurants>().HasOne(r => r.address).WithOne()
                .HasForeignKey<RestaurantAddresses>(x => x.restaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAddresses>().HasKey(x => x.addressId);
            builder.Entity<Entities.Users>()
                .HasOne(a => a.userAddress)
                .WithOne()
            .HasForeignKey<UserAddresses>(a => a.userId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserConfigs>().HasKey(x => x.id);
            builder.Entity<Entities.Users>().HasOne(c => c.userConfigs).WithOne().HasForeignKey<UserConfigs>(c => c.userId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Roles>()
                .HasData(
                    new Roles { Id = 1, Name = "Member", NormalizedName = "MEMBER" },
                    new Roles { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
