using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class EditUserAddressCommandHandler : ICommandHandler<EditUserAddressCommand, ResultT<JsonResponse>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditUserAddressCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultT<JsonResponse>> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _accountRepository.EditCurrentUserAddress(request.Request.UserAddressesForCreation,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = request.Request.Language == "EN"
                    ? DomainMessagesEn.Account.CanNotModifyAddress
                    : DomainMessagesRo.Account.CanNotModifyAddress
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.Account.AddressModified
                : DomainMessagesRo.Account.AddressModified
        };

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}