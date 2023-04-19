using DeliveryApp.Application.Mediatr.Query.StatisticsQuery;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Statistics;

public class MenuItemsCountQueryHandler : IQueryHandler<MenuItemsCountQuery, ResultT<List<MenuItemCountModel>>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public MenuItemsCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository =
            statisticsRepository ?? throw new ArgumentNullException(nameof(statisticsRepository));
    }

    public async Task<ResultT<List<MenuItemCountModel>>> Handle(MenuItemsCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _statisticsRepository.GetMenuItemCount(cancellationToken);
        return ResultT<List<MenuItemCountModel>>.Success(result);
    }
}