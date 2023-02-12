using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class
    UserConfigQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.UserConfig>, ResultT<Domain.Models.UserConfig>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigQueryItemHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<Domain.Models.UserConfig>> Handle(QueryItem<Domain.Models.UserConfig> request,
        CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.GetConfig(request.Id, cancellationToken);
        if (result == null)
            return ResultT<Domain.Models.UserConfig>.Failure($"Config with id {request.Id} does not exists");
        return ResultT<Domain.Models.UserConfig>.Success(result);
    }
}