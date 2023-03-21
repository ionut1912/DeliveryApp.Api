namespace DeliveryApp.Domain.Models;

public class MenuItem
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public bool Active { get; set; }
    public string Image { get; set; }
    public ICollection<ReviewForMenuItem> Reviews { get; set; } = new List<ReviewForMenuItem>();
}