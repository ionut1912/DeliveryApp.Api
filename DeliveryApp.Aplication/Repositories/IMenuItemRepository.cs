using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IMenuItemRepository
{
    Task<Result<MenuItems>> AddMenuItems(MenuItemCreateCommand request, CancellationToken cancellationToken);

    Task<Result<List<MenuItems>>> GetMenuItems(ListQuery<MenuItems> request,
        CancellationToken cancellationToken);

    Task<Result<MenuItems>> GetMenuItem(QueryItem<MenuItems> request,
        CancellationToken cancellationToken);

    Task<Result<Unit>> EditMenuItem(MenuItemEditCommand request, CancellationToken token);
}