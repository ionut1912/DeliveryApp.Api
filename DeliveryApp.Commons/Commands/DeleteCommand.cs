using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Commons.Commands;

public class DeleteCommand : ICommand<Result>
{
    public Guid Id { get; set; }
}