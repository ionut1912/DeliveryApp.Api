using DeliveryApp.Application.Mediatr.Commands.Account;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Account;

public class ForgotPasswordGenerateCodeCommandValidator : AbstractValidator<ForgotPasswordGenerateCodeCommand>
{
    public ForgotPasswordGenerateCodeCommandValidator()
    {
        RuleFor(x => x.Request.Email).NotEmpty().EmailAddress();
    }
}