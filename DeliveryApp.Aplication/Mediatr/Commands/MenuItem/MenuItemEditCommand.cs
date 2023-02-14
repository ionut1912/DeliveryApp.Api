using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.MenuItem;

public class MenuItemEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public MenuItemDto MenuItemDto { get; set; }
}