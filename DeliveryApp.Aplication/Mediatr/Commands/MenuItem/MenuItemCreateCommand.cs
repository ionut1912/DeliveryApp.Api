using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.MenuItem;

public class MenuItemCreateCommand : ICommand<Result<Domain.Models.MenuItem>>
{
    public Domain.Models.MenuItem MenuItemForCreation { get; set; }
}