using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Entities;
using DeliveryApp.Repository.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DeliveryApp.Repository.Context;

public class DeliveryContext : IdentityDbContext<Users, Roles, int>
{
    private readonly DatabaseSettings _dbSettings;


    public DeliveryContext(DbContextOptions<DeliveryContext> options, IOptions<DatabaseSettings> databaseSettings) : base(options)
    {
        _dbSettings = databaseSettings.Value;
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
    public DbSet<PhotoForRestaurant> PhotosForRestaurant { get; set; }
    public DbSet<ReviewForMenuItems> ReviewForMenuItems { get; set; }
    public DbSet<ReviewForRestaurants> ReviewForRestaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<OfferMenuItems>()
            .HasKey(x => new { x.OfferId, x.MenuItemId });
        builder.Entity<OfferMenuItems>().HasOne(offer => offer.Offer)
            .WithMany(om => om.OfferMenuItems)
            .HasForeignKey(id => id.OfferId);
        builder.Entity<OfferMenuItems>().HasOne(menuItem => menuItem.MenuItem)
            .WithMany(om => om.OfferMenuItems)
            .HasForeignKey(id => id.MenuItemId);
        builder.Entity<RestaurantAddresses>().HasKey(x => x.AddressId);
        builder.Entity<Restaurants>().HasOne(r => r.Address).WithOne()
            .HasForeignKey<RestaurantAddresses>(x => x.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<UserAddresses>().HasKey(x => x.AddressId);
        builder.Entity<Users>()
            .HasOne(a => a.UserAddress)
            .WithOne()
            .HasForeignKey<UserAddresses>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<UserConfigs>().HasKey(x => x.Id);
        builder.Entity<Users>().HasOne(c => c.UserConfigs).WithOne().HasForeignKey<UserConfigs>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Roles>()
            .HasData(
                new Roles { Id = 1, Name = "Member", NormalizedName = "MEMBER" },
                new Roles { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
            );
        
    }
}
