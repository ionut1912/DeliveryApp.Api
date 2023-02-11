using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.MenuItem;

public class MenuItemQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.MenuItem>, Result<Domain.Models.MenuItem>>
{
    private readonly IMenuItemRepository _repository;

    public MenuItemQueryItemHandler(IMenuItemRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Result<Domain.Models.MenuItem>> Handle(QueryItem<Domain.Models.MenuItem> request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetMenuItem(request, cancellationToken);
    }
}