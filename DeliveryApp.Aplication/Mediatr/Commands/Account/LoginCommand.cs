using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class LoginCommand : ICommand<ResultT<UserDto>>
{
    public LoginDto LoginDto { get; set; }
}