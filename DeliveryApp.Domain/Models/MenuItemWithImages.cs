using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Models
{
    public class MenuItemWithImages
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public List<string> Images { get; set; } = new();
        public ICollection<ReviewForMenuItem> Reviews { get; set; } = new List<ReviewForMenuItem>();
    }
}
