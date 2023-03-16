using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Domain.Messages;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Account
{
    public class CreateAccountCommandValidator:AbstractValidator<CreateAccountCommand>
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
}
