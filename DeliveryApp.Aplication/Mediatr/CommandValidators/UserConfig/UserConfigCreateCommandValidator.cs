using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators.UserConfig;

public class UserConfigCreateCommandValidator : AbstractValidator<UserConfigCreateCommand>
{
    public UserConfigCreateCommandValidator()
    {
        RuleFor(x => x.UserConfigs.Weight).NotEmpty().WithMessage("Weight should not be empty").GreaterThan(0)
            .WithMessage("Weight should be grater than 0");
        RuleFor(x => x.UserConfigs.Height).NotEmpty().WithMessage("Height should not be empty").GreaterThan(0)
            .WithMessage("Height should be grater than 0");
        RuleFor(x => x.UserConfigs.Age).NotEmpty().WithMessage("Age should not be empty");
        RuleFor(x => x.UserConfigs.Sex).NotEmpty().WithMessage("Sex should not be empty");
    }
}