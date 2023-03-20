using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.DTO
{
    public class ReviewForMenuItemDto
    {
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public Guid MenuItemId { get; set; }

    }
}
