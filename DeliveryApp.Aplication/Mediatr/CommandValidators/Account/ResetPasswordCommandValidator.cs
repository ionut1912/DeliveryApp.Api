using DeliveryApp.Application.Mediatr.Commands.Account;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Account;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Request.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Request.Password).NotEmpty().MinimumLength(8).MaximumLength(32);
    }
}