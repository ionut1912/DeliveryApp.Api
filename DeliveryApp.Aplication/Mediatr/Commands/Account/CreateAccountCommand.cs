using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class CreateAccountCommand : ICommand<ResultT<JsonResponse>>
{
    public RegisterDto RegisterDto { get; set; }
    public ModelStateDictionary ModelState { get; set; }
}