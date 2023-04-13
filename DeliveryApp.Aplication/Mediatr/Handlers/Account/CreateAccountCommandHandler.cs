using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, ResultT<JsonResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<JsonResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.Register(request.RegisterDto, request.ModelState, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Account.ProblemCreatingAccount
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Account.AccountCreatedSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}