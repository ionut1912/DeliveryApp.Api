namespace DeliveryApp.Repository.Entities;

public class Orders
{
    public Guid id { get; set; }
    public DateTime reciviedTime { get; set; }
    public float finalPrice { get; set; }
    public string status { get; set; }
    public Users user { get; set; }
    public Restaurants restaurant { get; set; }
    public List<MenuItems> menuItems { get; set; } = new();
}