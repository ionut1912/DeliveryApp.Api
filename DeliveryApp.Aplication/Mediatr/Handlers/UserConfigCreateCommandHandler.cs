using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class UserConfigCreateCommandHandler : ICommandHandler<UserConfigCreateCommand, Result<UserConfigs>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigCreateCommandHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<Result<UserConfigs>> Handle(UserConfigCreateCommand request, CancellationToken cancellationToken)
    {
        return await _userConfigRepository.AddConfig(request, cancellationToken);
    }
}