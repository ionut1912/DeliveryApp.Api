using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.Account;

public class ForgotPasswordGenerateCodeCommand : ICommand<ResultT<JsonResponse>>
{
    public ForgotPasswordResetCodeRequest Request { get; set; }
}