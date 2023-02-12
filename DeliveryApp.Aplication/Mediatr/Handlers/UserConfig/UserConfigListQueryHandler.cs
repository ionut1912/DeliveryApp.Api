using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class
    UserConfigListQueryHandler : IQueryHandler<ListQuery<Domain.Models.UserConfigDto>,
        ResultT<List<Domain.Models.UserConfigDto>>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigListQueryHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<List<Domain.Models.UserConfigDto>>> Handle(ListQuery<Domain.Models.UserConfigDto> request,
        CancellationToken cancellationToken)
    {
        return await _userConfigRepository.GetConfigs(request, cancellationToken);
    }
}