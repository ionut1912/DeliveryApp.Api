using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoForMenuItemSetMainCommand : ICommand<Result>
{
    public string PhotoId { get; set; }
    public Guid ItemId { get; set; }
}