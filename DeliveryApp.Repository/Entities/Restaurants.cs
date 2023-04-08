﻿using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Repository.Entities;

public class Restaurants
{
    public ICollection<PhotoForRestaurant> RestaurantPhotos { get; set; } = new List<PhotoForRestaurant>();
    public Guid Id { get; set; }
    public string Name { get; set; }

    public RestaurantAddresses Address { get; set; }
    public List<MenuItems> MenuItems { get; set; } = new();
    public List<Orders> Orders { get; set; } = new();
    public ICollection<ReviewForRestaurants> Reviews { get; set; } = new List<ReviewForRestaurants>();
}