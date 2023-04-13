using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoForRestaurantCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public IFormFile File { get; set; }
    public Guid Id { get; set; }
}