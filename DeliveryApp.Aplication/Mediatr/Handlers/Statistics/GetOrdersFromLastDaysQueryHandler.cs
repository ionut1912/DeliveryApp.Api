using DeliveryApp.Application.Mediatr.Query.StatisticsQuery;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Statistics;

public class
    GetOrdersFromLastDaysQueryHandler : IQueryHandler<GetOrdersFromLastDaysQuery, ResultT<OrderDetailStatistic>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public GetOrdersFromLastDaysQueryHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository =
            statisticsRepository ?? throw new ArgumentNullException(nameof(statisticsRepository));
    }

    public async Task<ResultT<OrderDetailStatistic>> Handle(GetOrdersFromLastDaysQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _statisticsRepository.GetOrderFromLastDays(request.NumberOfDays, cancellationToken);
        return ResultT<OrderDetailStatistic>.Success(result);
    }
}