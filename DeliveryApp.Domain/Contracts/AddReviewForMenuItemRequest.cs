using DeliveryApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Contracts
{
    public class AddReviewForMenuItemRequest
    {
        public string Language { get; set; }
        public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
    }
}
