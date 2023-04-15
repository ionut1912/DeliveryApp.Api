namespace DeliveryApp.Domain.Models;

public class MenuItemRestaurant
{
    public Guid MenuItemsId { get; set; }
    public MenuItem MenuItems { get; set; }
    public Guid RestaurantsId { get; set; }
    public Restaurant Restaurants { get; set; }
}