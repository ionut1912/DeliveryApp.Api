using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.MenuItemDto>, ResultT<Domain.Models.MenuItemDto>>
{
    private readonly IMenuItemRepository _repository;

    public MenuItemQueryItemHandler(IMenuItemRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultT<Domain.Models.MenuItemDto>> Handle(QueryItem<Domain.Models.MenuItemDto> request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetMenuItem(request, cancellationToken);
    }
}