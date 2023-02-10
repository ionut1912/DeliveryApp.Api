using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class UserConfigQueryItemByUsernameHandler : IQueryHandler<UserConfigQueryItemByUsername, Result<UserConfigs>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigQueryItemByUsernameHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<Result<UserConfigs>> Handle(UserConfigQueryItemByUsername request,
        CancellationToken cancellationToken)
    {
        return await _userConfigRepository.GetConfigByUsername(request, cancellationToken);
    }
}