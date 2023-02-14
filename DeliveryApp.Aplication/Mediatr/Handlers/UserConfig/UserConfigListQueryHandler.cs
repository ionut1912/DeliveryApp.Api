using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class UserConfigListQueryHandler : IQueryHandler<ListQuery<Domain.Models.UserConfig>,
    ResultT<List<Domain.Models.UserConfig>>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigListQueryHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<List<Domain.Models.UserConfig>>> Handle(ListQuery<Domain.Models.UserConfig> request,
        CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.GetConfigs(cancellationToken);
        return ResultT<List<Domain.Models.UserConfig>>.Success(result);
    }
}