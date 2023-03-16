using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.UserConfig;

public class UserConfigCreateCommandValidator : AbstractValidator<UserConfigCreateCommand>
{
    public UserConfigCreateCommandValidator()
    {
        RuleFor(x => x.UserConfigs.Weight).NotEmpty().GreaterThan(0);
        RuleFor(x => x.UserConfigs.Height).NotEmpty().GreaterThan(0);
        RuleFor(x => x.UserConfigs.Age).NotEmpty();
        RuleFor(x => x.UserConfigs.Sex).NotEmpty();
    }
}   