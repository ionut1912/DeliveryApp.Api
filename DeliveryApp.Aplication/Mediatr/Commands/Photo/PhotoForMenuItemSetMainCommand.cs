﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoForMenuItemSetMainCommand : ICommand<ResultT<Unit>>
{
    public string PhotoId { get; set; }
    public Guid ItemId { get; set; }
}