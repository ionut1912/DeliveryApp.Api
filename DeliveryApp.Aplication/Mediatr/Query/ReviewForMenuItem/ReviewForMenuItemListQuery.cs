using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;

public class ReviewForMenuItemListQuery : ListQuery<Domain.Models.ReviewForMenuItem>
{
    public Guid MenuItemId { get; set; }
}