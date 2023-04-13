using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Models;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class EditUserAddressCommand : ICommand<ResultT<JsonResponse>>
{
    public UserAddressesForCreation UserAddressesForCreation { get; set; }
}