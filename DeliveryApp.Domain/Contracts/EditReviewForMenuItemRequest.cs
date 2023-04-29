using DeliveryApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Contracts
{
    public class EditReviewForMenuItemRequest
    {
        public string Language { get; set; }
        public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
    }
}
