using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.MenuItem;

public class MenuItemEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public MenuItemForUpdate MenuItemForUpdate { get; set; }
}