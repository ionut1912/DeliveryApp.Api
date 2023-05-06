using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class GetResetPasswordCodeQueryHandler : IQueryHandler<GetResetPasswordCodeQuery, ResultT<UserCodeContract>>
{
    private readonly IAccountRepository _accountRepository;

    public GetResetPasswordCodeQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<UserCodeContract>> Handle(GetResetPasswordCodeQuery request,
        CancellationToken cancellationToken)
    {
        var code = await _accountRepository.GetResetPasswordCode(request.Email, cancellationToken);
        var userCodeContract = new UserCodeContract
        {
            Code = code
        };
        return ResultT<UserCodeContract>.Success(userCodeContract);
    }
}