﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Models
{
    public class UserConfigForCreation
    {
        public string username { get; set; }
        public float weight { get; set; }
        public int height { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
    }
}
