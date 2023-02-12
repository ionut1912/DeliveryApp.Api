using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class UserConfigCreateCommandHandler : ICommandHandler<UserConfigCreateCommand, ResultT<Domain.Models.UserConfigDto>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigCreateCommandHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<Domain.Models.UserConfigDto>> Handle(UserConfigCreateCommand request,
        CancellationToken cancellationToken)
    {
        return await _userConfigRepository.AddConfig(request, cancellationToken);
    }
}