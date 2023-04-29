using DeliveryApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Contracts
{
    public class CreateOrderRequest
    {
        public string Language { get; set; }
        public OrderForCreationDto Order { get; set; }
    }
}
