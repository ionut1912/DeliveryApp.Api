using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Account
{
    public class GetAllUsersQueryHandler:IQueryHandler<GetAllUsersQuery,ResultT<List<User>>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAllUsersQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<ResultT<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _accountRepository.GetAllUsers(cancellationToken);
            return  ResultT<List<User>>.Success(users);
        }
    }
}
