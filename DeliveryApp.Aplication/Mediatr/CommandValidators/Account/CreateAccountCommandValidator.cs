using DeliveryApp.Application.Mediatr.Commands.Account;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Account;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(x => x.RegisterDto.PhoneNumber)
            .NotEmpty()
            .MaximumLength(10);


        RuleFor(x => x.RegisterDto.Username)
            .NotEmpty();
        RuleFor(x => x.RegisterDto.Email)
            .NotEmpty()
            .EmailAddress();
    }
}