using DeliveryApp.Commons.Commands;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemDeleteCommand : DeleteCommand
{
  public  DeleteReviewForMenuItemRequest Request { get; set; }
}