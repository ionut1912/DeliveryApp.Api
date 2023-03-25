using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.MenuItem;

public class
    MenuItemQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.MenuItemWithImages>, ResultT<Domain.Models.MenuItemWithImages>>
{
    private readonly IMenuItemRepository _repository;

    public MenuItemQueryItemHandler(IMenuItemRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultT<Domain.Models.MenuItemWithImages>> Handle(QueryItem<Domain.Models.MenuItemWithImages> request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetMenuItem(request.Id, cancellationToken);
        if (result == null)
            return ResultT<Domain.Models.MenuItemWithImages>.Failure(DomainMessages.MenuItem.NotFoundMenuItem(request.Id));
        return ResultT<Domain.Models.MenuItemWithImages>.Success(result);
    }
}