﻿namespace DeliveryApp.Domain.DTO;

public class ReviewForRestaurantDto
{
    public string ReviewTitle { get; set; }
    public string ReviewDescription { get; set; }
    public int NumberOfStars { get; set; }
    public Guid RestaurantId { get; set; }
}