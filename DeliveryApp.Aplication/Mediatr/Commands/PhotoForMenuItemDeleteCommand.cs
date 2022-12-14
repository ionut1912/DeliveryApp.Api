using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands;

public class PhotoForMenuItemDeleteCommand : ICommand<Result<Unit>>
{
    public string photoId { get; set; }
    public Guid itemId { get; set; }
}