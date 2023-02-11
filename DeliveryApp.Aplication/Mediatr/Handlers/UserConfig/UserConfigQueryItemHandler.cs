using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class
    UserConfigQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.UserConfig>, Result<Domain.Models.UserConfig>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigQueryItemHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<Result<Domain.Models.UserConfig>> Handle(QueryItem<Domain.Models.UserConfig> request,
        CancellationToken cancellationToken)
    {
        return await _userConfigRepository.GetConfig(request, cancellationToken);
    }
}