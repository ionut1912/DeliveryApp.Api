using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;
using DeliveryApp.Domain.Models;
using Microsoft.Extensions.Options;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class EditUserCommandHandler : ICommandHandler<EditUserCommand, ResultT<EditCurrentUserResponse>>
{
    private readonly IAccountRepository _accountRepository;
   

    public EditUserCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<EditCurrentUserResponse>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _accountRepository.EditCurrentUser(request.UserToBeEdited, request.ModelState, cancellationToken);
      
        return ResultT<EditCurrentUserResponse>.Success(result);
    }
}