using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Commons.Commands;

public class DeleteCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
}