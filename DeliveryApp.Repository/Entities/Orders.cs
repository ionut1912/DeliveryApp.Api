namespace DeliveryApp.Repository.Entities;

public class Orders
{
    public Guid Id { get; set; }
    public DateTime ReceivedTime { get; set; }
    public double FinalPrice { get; set; }
    public string Status { get; set; }
    public Users User { get; set; }
    public List<Restaurants> Restaurants { get; set; }
    public  List<MenuItems> MenuItems { get; set; }
}