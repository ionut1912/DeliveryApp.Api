﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemEditCommand : ICommand<ResultT<JsonResponse>>
{
    public Guid Id { get; set; }
    public  EditReviewForMenuItemRequest Request { get; set; }

}