using DeliveryApp.Application.Mediatr.Query;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class
    UserConfigQueryItemByUsernameHandler : IQueryHandler<UserConfigQueryItemByUsername,
        ResultT<Domain.Models.UserConfig>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigQueryItemByUsernameHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<Domain.Models.UserConfig>> Handle(UserConfigQueryItemByUsername request,
        CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.GetConfigByUsername(cancellationToken);
        return ResultT<Domain.Models.UserConfig>.Success(result);
    }
}