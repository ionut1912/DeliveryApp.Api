using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.Restaurant;

public class RestaurantQueryItemByCity : IQuery<ResultT<List<RestaurantWithImage>>>
{
    public string City { get; set; }
}