namespace DeliveryApp.Repository.Entities;

public class Orders
{
    public Guid Id { get; set; }
    public DateTime ReciviedTime { get; set; }
    public double FinalPrice { get; set; }
    public string Status { get; set; }
    public Users User { get; set; }
    public Restaurants Restaurant { get; set; }
    public List<MenuItems> MenuItems { get; set; } = new();
}