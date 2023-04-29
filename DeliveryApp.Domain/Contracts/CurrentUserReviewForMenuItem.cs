namespace DeliveryApp.Domain.Contracts;

public class CurrentUserReviewForMenuItem
{
    public Guid Id { get; set; }
    public string ReviewTitle { get; set; }
    public string ReviewDescription { get; set; }
    public int NumberOfStars { get; set; }
    public string Username { get; set; }
    public Guid MenuItemId { get; set; }
    public string ItemName { get; set; }
}