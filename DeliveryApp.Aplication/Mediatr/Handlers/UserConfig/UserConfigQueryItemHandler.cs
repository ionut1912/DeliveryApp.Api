using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

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
            return ResultT<Domain.Models.UserConfig>.Failure(
                DomainMessagesEn.UserConfig.NotFoundUserConfig(request.Id));
        return ResultT<Domain.Models.UserConfig>.Success(result);
    }
}