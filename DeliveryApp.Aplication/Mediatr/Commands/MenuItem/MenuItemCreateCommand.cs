using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.MenuItem;

public class MenuItemCreateCommand : ICommand<Result>
{
    public MenuItemDto MenuItemDto { get; set; }
}