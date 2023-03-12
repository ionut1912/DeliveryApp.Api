using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Query.Restaurant
{
    public class RestaurantQueryItemByCity:IQuery<ResultT<List<Domain.Models.Restaurant>>>
    {
        public string City { get; set; }
    }
}
