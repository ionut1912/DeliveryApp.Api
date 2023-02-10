using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class UserConfigUpdateCommandHandler : ICommandHandler<UserConfigsUpdateCommand, Result<Unit>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigUpdateCommandHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<Result<Unit>> Handle(UserConfigsUpdateCommand request, CancellationToken cancellationToken)
    {
        return await _userConfigRepository.EditConfig(request, cancellationToken);
    }
}