using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Models;

public class ReviewForMenuItem
{
    public Guid Id { get; set; }
    public string ReviewTitle { get; set; }
    public string ReviewDescription { get; set; }
    public int NumberOfStars { get;set; }
    public UserDto User { get; set; }
    public Guid MenuItemsId { get; set; }
}