using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class ResetPasswordCommand : ICommand<ResultT<JsonResponse>>
{
    public ResetPasswordRequest Request { get; set; }
}