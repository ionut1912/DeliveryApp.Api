using DeliveryApp.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.DTO
{
    public class UserDto
    {
        public string token { get; set; }
        public string username { get; set; }
        public string? image { get; set; }
        public UserAddressesForCreation address { get; set; }
    }
}
