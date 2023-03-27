using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class
    MenuItemQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.MenuItem>, ResultT<Domain.Models.MenuItem>>
{
    private readonly IMenuItemRepository _repository;

    public MenuItemQueryItemHandler(IMenuItemRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultT<Domain.Models.MenuItem>> Handle(QueryItem<Domain.Models.MenuItem> request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetMenuItem(request.Id, cancellationToken);
        if (result == null)
            return ResultT<Domain.Models.MenuItem>.Failure(DomainMessages.MenuItem.NotFoundMenuItem(request.Id));
        return ResultT<Domain.Models.MenuItem>.Success(result);
    }
}