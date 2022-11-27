using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class UserConfigCreateCommandValidator : AbstractValidator<UserConfigCreateCommand>
{
    public UserConfigCreateCommandValidator()
    {
        RuleFor(x => x.userConfigs.username).NotEmpty().WithMessage("Username should not be empty");
        RuleFor(x => x.userConfigs.weight).NotEmpty().WithMessage("Weight should not be empty").GreaterThan(0)
            .WithMessage("Weight should be grater than 0");
        RuleFor(x => x.userConfigs.height).NotEmpty().WithMessage("Height should not be empty").GreaterThan(0)
            .WithMessage("Height should be grater than 0");
        RuleFor(x => x.userConfigs.age).NotEmpty().WithMessage("Age should not be empty");
        RuleFor(x => x.userConfigs.sex).NotEmpty().WithMessage("Sex should not be empty");
    }
}