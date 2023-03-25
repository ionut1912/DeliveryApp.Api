using DeliveryApp.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Models
{
    public class RestaurantWithImages
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; } = new();
        public RestaurantAddresses Address { get; set; }
        public List<MenuItemWithImage> MenuItems { get; set; } = new();

        public List<ReviewForRestaurant> Reviews { get; set; } = new();
    }
}
