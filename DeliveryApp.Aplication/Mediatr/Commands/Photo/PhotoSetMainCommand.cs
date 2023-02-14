using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoSetMainCommand : ICommand<Result>
{
    public string Id { get; set; }
}