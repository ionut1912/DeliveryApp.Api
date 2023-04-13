using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoDeleteCommand : ICommand<ResultT<JsonResponse>>
{
    public string Id { get; set; }
}