using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.UserConfig;

public class UserConfigEditCommandValidator : AbstractValidator<UserConfigsUpdateCommand>
{
    public UserConfigEditCommandValidator()
    {
        RuleFor(x => x.Request.Configs.Weight).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Request.Configs.Height).GreaterThan(0);
        RuleFor(x => x.Request.Configs.Age).NotEmpty();
        RuleFor(x => x.Request.Configs.Sex).NotEmpty();
    }
}