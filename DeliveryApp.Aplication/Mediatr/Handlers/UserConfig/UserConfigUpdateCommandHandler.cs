using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class UserConfigUpdateCommandHandler : ICommandHandler<UserConfigsUpdateCommand, ResultT<JsonResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigUpdateCommandHandler(IUserConfigRepository userConfigRepository, IUnitOfWork unitOfWork)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(UserConfigsUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.EditConfig(request.Id, request.Configs, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.UserConfig.NotFoundUserConfig(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.UserConfig.ConfigEditedSuccessfully(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}