using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoDeleteCommand : ICommand<Result>
{
    public string Id { get; set; }
}