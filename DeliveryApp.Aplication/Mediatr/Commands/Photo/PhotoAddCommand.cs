﻿using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoAddCommand : ICommand<Result>

{
    public IFormFile File { get; set; }
}