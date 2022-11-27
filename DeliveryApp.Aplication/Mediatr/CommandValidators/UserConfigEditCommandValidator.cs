using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class UserConfigEditCommandValidator : AbstractValidator<UserConfigsUpdateCommand>
{
    public UserConfigEditCommandValidator()
    {
        RuleFor(x => x.configs.username).NotEmpty().WithMessage("Username should not be empty");
        RuleFor(x => x.configs.weight).NotEmpty().WithMessage("Weight should not be empty").GreaterThan(0)
            .WithMessage("Weight should be grater than 0");
        RuleFor(x => x.configs.height).NotEmpty().WithMessage("Height should not be empty").GreaterThan(0)
            .WithMessage("Height should be grater than 0");
        RuleFor(x => x.configs.age).NotEmpty().WithMessage("Age should not be empty");
        RuleFor(x => x.configs.sex).NotEmpty().WithMessage("Sex should not be empty");
    }
}