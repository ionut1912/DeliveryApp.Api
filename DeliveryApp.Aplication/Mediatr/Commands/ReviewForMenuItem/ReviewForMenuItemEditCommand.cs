﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
}