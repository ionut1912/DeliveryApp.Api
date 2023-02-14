using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoForMenuItemCreateCommand : ICommand<Result>
{
    public IFormFile File { get; set; }
    public Guid Id { get; set; }
}