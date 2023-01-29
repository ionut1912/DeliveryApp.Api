using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class UserConfigEditCommandValidator : AbstractValidator<UserConfigsUpdateCommand>
{
    public UserConfigEditCommandValidator()
    {
        RuleFor(x => x.Configs.Username).NotEmpty().WithMessage("Username should not be empty");
        RuleFor(x => x.Configs.Weight).NotEmpty().WithMessage("Weight should not be empty").GreaterThan(0)
            .WithMessage("Weight should be grater than 0");
        RuleFor(x => x.Configs.Height).NotEmpty().WithMessage("Height should not be empty").GreaterThan(0)
            .WithMessage("Height should be grater than 0");
        RuleFor(x => x.Configs.Age).NotEmpty().WithMessage("Age should not be empty");
        RuleFor(x => x.Configs.Sex).NotEmpty().WithMessage("Sex should not be empty");
    }
}