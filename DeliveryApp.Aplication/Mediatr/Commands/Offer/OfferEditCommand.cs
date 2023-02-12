﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Offer;

public class OfferEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
   public  OfferDto OfferDto { get; set; }
}