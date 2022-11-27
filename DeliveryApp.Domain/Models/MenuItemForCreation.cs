namespace DeliveryApp.Domain.Models;

public class MenuItemForCreation
{
    public string itemName { get; set; }
    public string category { get; set; }
    public string ingredients { get; set; }
    public float price { get; set; }
    public int quantity { get; set; }
}