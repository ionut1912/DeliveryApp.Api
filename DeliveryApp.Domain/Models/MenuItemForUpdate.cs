using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Models
{
    public class MenuItemForUpdate
    {

        public string itemName { get; set; }
        public string category { get; set; }
        public string ingredients { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

    }
}
