using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands
{
    public class PhotoDeleteCommand : ICommand<Result<Unit>>
    {
        public string Id { get; set; }
        public string email { get; set; }
    }
}
