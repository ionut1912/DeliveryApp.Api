using DeliveryApp.Application.Mediatr.Query.StatisticsQuery;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Statistics;

public class
    MenuItemInOrdersCountQueryHandler : IQueryHandler<MenuItemInOrdersCountQuery,
        ResultT<List<MenuItemInOrderCountModel>>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public MenuItemInOrdersCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository =
            statisticsRepository ?? throw new ArgumentNullException(nameof(statisticsRepository));
    }

    public async Task<ResultT<List<MenuItemInOrderCountModel>>> Handle(MenuItemInOrdersCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _statisticsRepository.GetMenuItemInOrderCount(cancellationToken);
        return ResultT<List<MenuItemInOrderCountModel>>.Success(result);
    }
}