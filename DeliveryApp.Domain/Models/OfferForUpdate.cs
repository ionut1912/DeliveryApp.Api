﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Models
{
    public class OfferForUpdate
    {
        public string dateActiveFrom { get; set; }
        public string dateActiveTo { get; set; }
        public int discount { get; set; }
        public Guid menuItemId { get; set; }
    }
}
