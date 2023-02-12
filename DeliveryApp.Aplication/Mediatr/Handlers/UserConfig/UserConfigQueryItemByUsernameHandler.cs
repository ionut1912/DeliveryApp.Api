using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

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