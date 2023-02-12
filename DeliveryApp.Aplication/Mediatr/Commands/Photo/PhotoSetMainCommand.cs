using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoSetMainCommand : ICommand<ResultT<Unit>>
{
    public string Id { get; set; }
}