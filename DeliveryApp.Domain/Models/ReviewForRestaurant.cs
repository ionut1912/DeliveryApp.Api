﻿namespace DeliveryApp.Domain.Models;

public class ReviewForRestaurant
{
    public Guid Id { get; set; }
    public string ReviewTitle { get; set; }
    public string ReviewDescription { get; set; }
    public int NumberOfStars { get; set; }
    public User User { get; set; }
    public Guid RestaurantsId { get; set; }
}