using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class UserConfigsDeleteCommandHandler : ICommandHandler<DeleteCommand, Result<Unit>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigsDeleteCommandHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<Result<Unit>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        return await _userConfigRepository.DeleteConfig(request, cancellationToken);
    }
}