using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class EditUserCommandHandler : ICommandHandler<EditUserCommand, Result>
{
    private readonly IAccountRepository _accountRepository;

    public EditUserCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<Result> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _accountRepository.EditCurrentUser(request.UserToBeEdited, request.ModelState, cancellationToken);
        if (result is false)
            return Result.Failure(DomainMessages.Account.ProblemModifyingAccount);
        return Result.Success(DomainMessages.Account.AccountModifiedSuccessfully);
    }
}