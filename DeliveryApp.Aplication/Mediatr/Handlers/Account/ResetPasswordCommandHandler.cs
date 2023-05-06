using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, ResultT<JsonResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public ResetPasswordCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<JsonResponse>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.ModifyUserPassword(request.Request.Email, request.Request.Password,
            cancellationToken);
        if (result == false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = request.Request.Language == "EN"
                    ? DomainMessagesEn.Account.IssuesResetingPassword
                    : DomainMessagesRo.Account.IssuesResetingPassword
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.Account.PasswordResetedSuccessfully
                : DomainMessagesRo.Account.PasswordResetedSuccessfully
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}