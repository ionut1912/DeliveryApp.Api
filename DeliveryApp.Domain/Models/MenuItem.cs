namespace DeliveryApp.Domain.Models;

public class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
}