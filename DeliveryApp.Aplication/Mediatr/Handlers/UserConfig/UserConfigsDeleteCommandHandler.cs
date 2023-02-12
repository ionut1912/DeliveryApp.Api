using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class UserConfigsDeleteCommandHandler : ICommandHandler<DeleteCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigsDeleteCommandHandler(IUserConfigRepository userConfigRepository, IUnitOfWork unitOfWork)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _userConfigRepository.DeleteConfig(request.Id, cancellationToken);
        if (result is false) return Result.Failure($"Config with id {request.Id} can not be deleted");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Config deleted successfully");
    }
}