using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Models;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class EditUserAddressCommand : ICommand<Result>
{
    public UserAddressesForCreation UserAddressesForCreation { get; set; }
}