using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;

public class ReviewForMenuItemQueryItem : QueryItem<Domain.Models.ReviewForMenuItem>
{
    public Guid MenuItemId { get; set; }
}