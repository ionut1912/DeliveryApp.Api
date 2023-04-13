using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.UserConfig;

public class UserConfigsDeleteCommandHandler : ICommandHandler<DeleteCommand, ResultT<JsonResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigsDeleteCommandHandler(IUserConfigRepository userConfigRepository, IUnitOfWork unitOfWork)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.DeleteConfig(request.Id, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.UserConfig.CanNotDeleteConfig(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.UserConfig.ConfigDeletedSuccessfully(request.Id)
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}