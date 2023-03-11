using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class UserConfigUpdateCommandHandler : ICommandHandler<UserConfigsUpdateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigUpdateCommandHandler(IUserConfigRepository userConfigRepository, IUnitOfWork unitOfWork)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(UserConfigsUpdateCommand request, CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.EditConfig(request.Id, request.Configs, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.UserConfig.NotFoundUserConfig(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.UserConfig.ConfigEditedSuccessfully(request.Id));
    }
}