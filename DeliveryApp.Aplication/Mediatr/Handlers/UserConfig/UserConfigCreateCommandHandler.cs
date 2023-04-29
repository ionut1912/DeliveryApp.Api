using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class UserConfigCreateCommandHandler : ICommandHandler<UserConfigCreateCommand, ResultT<JsonResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigCreateCommandHandler(IUserConfigRepository userConfigRepository, IUnitOfWork unitOfWork)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(UserConfigCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _userConfigRepository.AddConfig(request.Request.UserConfig, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.UserConfig.UserConfigAddedSuccessfully
                : DomainMessagesRo.UserConfig.UserConfigAddedSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}