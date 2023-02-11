using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IMenuItemRepository
{
    Task<Result<MenuItem>> AddMenuItems(MenuItemCreateCommand request, CancellationToken cancellationToken);

    Task<Result<List<MenuItem>>> GetMenuItems(ListQuery<MenuItem> request,
        CancellationToken cancellationToken);

    Task<Result<MenuItem>> GetMenuItem(QueryItem<MenuItem> request,
        CancellationToken cancellationToken);

    Task<Result<Unit>> EditMenuItem(MenuItemEditCommand request, CancellationToken token);
}