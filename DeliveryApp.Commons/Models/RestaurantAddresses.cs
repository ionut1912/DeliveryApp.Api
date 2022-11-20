﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Commons.Models
{
    public  class RestaurantAddresses
    {
        public  Guid addressId { get; set; }
        public Guid restaurantId { get; set; }
        public  string street { get; set; }
        public string number { get; set; }
        public  string city { get; set; }
        public  string postalCode { get; set; }
    }
}
