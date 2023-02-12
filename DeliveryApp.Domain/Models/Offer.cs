namespace DeliveryApp.Repository.Entities;

public class Offer
{
    public Guid Id { get; set; }
    public string DateActiveFrom { get; set; }
    public string DateActiveTo { get; set; }
    public int Discount { get; set; }
    public bool Active { get; set; }
}