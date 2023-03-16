using DeliveryApp.Application.Mediatr.Commands.Account;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Account;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.LoginDto.Username)
            .NotEmpty();
        RuleFor(x => x.LoginDto.Password)
            .NotEmpty();
        RuleFor(x => x.LoginDto.Email)
            .NotEmpty()
            .EmailAddress();
    }
}