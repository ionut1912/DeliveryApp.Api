namespace DeliveryApp.Repository.Entities;

public class MenuItemsRestaurants
{
    public Guid MenuItemsId { get; set; }
    public MenuItems MenuItems { get; set; }
    public Guid RestaurantsId { get; set; }
    public Restaurants Restaurants { get; set; }
}