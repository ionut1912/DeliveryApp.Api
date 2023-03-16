using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, Result>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.Register(request.RegisterDto, request.ModelState, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.Account.ProblemCreatingAccount);

        return Result.Success(DomainMessages.Account.AccountCreatedSuccessfully);
    }
}