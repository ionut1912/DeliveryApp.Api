using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Repository.Entities
{
    public class MenuItemsRestaurants
    {
        public Guid MenuItemsId { get; set; }
        public  MenuItems MenuItems { get; set; }
        public  Guid RestaurantsId { get; set; }
        public Restaurants Restaurants { get; set; }
    }
}
