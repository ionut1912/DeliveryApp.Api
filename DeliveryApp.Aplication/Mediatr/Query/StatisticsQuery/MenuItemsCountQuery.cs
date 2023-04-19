using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.StatisticsQuery;

public class MenuItemsCountQuery : IQuery<ResultT<List<MenuItemCountModel>>>
{
}