using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.Orders;

public class CurrentUserOrdersQuery : IQuery<ResultT<List<Order>>>
{
}