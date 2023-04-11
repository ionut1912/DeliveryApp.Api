namespace DeliveryApp.Domain.DTO;

public class MenuItemDto
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public float Price { get; set; }
    public int NumberOfCalories { get; set; }
    public int Quantity { get; set; }
}