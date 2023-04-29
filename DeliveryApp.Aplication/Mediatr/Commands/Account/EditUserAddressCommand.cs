using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class EditUserAddressCommand : ICommand<ResultT<JsonResponse>>
{
    public  EditUserAddressRequest Request { get; set; }
}