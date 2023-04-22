using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Query.StatisticsQuery;

public class MenuItemInOrdersCountQuery : IQuery<ResultT<List<MenuItemInOrderCountModel>>>
{
}