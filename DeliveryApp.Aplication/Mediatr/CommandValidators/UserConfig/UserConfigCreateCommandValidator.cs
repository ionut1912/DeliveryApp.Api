using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.UserConfig;

public class UserConfigCreateCommandValidator : AbstractValidator<UserConfigCreateCommand>
{
    public UserConfigCreateCommandValidator()
    {
        RuleFor(x => x.Request.UserConfig.Weight).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Request.UserConfig.Height).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Request.UserConfig.Age).NotEmpty();
        RuleFor(x => x.Request.UserConfig.Sex).NotEmpty();
        RuleFor(x => x.Request.UserConfig.SportActivity).NotEmpty();
    }
}