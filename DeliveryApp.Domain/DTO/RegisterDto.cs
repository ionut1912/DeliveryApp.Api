﻿using DeliveryApp.Commons.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.DTO
{
    public class RegisterDto
    {
        [Required][EmailAddress] public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Username { get; set; }

        public UserAddressesForCreation addressForCreation { get; set; }
    }
}
