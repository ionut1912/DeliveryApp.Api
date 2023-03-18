using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class EditUserAddressCommandHandler : ICommandHandler<EditUserAddressCommand, Result>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditUserAddressCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _accountRepository.EditCurrentUserAddress(request.UserAddressesForCreation, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.Account.CanNotModifyAddress);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.Account.AddressModified);
    }
}