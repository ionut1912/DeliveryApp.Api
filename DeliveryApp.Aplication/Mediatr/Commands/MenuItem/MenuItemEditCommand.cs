using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.MenuItem;

public class MenuItemEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public Domain.Models.MenuItem MenuItemForUpdate { get; set; }
}