using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Account;

public class GetCurrentUserQueryHandler : IQueryHandler<GetCurrentUserQuery, ResultT<User>>
{
    private readonly IAccountRepository _accountRepository;

    public GetCurrentUserQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task<ResultT<User>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.GetCurrentUser(request.Username, cancellationToken);
        return ResultT<User>.Success(result);
    }
}