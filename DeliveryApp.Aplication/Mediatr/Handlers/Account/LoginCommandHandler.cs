using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class LoginCommandHandler : ICommandHandler<LoginCommand, ResultT<UserDto>>
{
    private readonly IAccountRepository _accountRepository;

    public LoginCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.Login(request.LoginDto, cancellationToken);
        return ResultT<UserDto>.Success(result);
    }
}