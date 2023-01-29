﻿using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class RestaurantForCreation
{
    public string Name { get; set; }
    public RestaurantAddressesForCreation Address { get; set; }
}