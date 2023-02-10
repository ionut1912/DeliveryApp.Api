using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemQueryItemHandler : IQueryHandler<QueryItem<MenuItems>, Result<MenuItems>>
{
    private readonly IMenuItemRepository _repository;

    public MenuItemQueryItemHandler(IMenuItemRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Result<MenuItems>> Handle(QueryItem<MenuItems> request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetMenuItem(request, cancellationToken);
    }
}