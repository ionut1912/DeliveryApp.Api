﻿using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Domain.Models;

public class MenuItem
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public float Price { get; set; }
    public int NumberOfCalories { get; set; }
    public int Quantity { get; set; }
    public bool Active { get; set; }

    public ICollection<PhotoForMenuItem> Photos { get; set; } =
        new List<PhotoForMenuItem>();

    public ICollection<OfferMenuItem> OfferMenuItems { get; set; } = new List<OfferMenuItem>();
    public ICollection<ReviewForMenuItem> Reviews { get; set; } = new List<ReviewForMenuItem>();
    public List<Restaurant> Restaurants { get; set; } = new();
}