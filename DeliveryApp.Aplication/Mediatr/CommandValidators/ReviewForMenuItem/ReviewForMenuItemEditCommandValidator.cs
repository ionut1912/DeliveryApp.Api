﻿using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;

public class ReviewForMenuItemEditCommandValidator : AbstractValidator<ReviewForMenuItemEditCommand>
{
    public ReviewForMenuItemEditCommandValidator()
    {
        RuleFor(x => x.ReviewForMenuItemDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.ReviewForMenuItemDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.ReviewForMenuItemDto.MenuItemId).NotEmpty();
    }
}