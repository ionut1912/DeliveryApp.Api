using DeliveryApp.Commons.Commands;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemDeleteCommand : DeleteCommand
{
    public string Language { get; set; }
}