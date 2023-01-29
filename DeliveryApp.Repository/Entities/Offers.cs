namespace DeliveryApp.Repository.Entities;

public class Offers
{
    public Guid Id { get; set; }
    public DateTime DateActiveFrom { get; set; }
    public DateTime DateActiveTo { get; set; }
    public int Discount { get; set; }
    public bool Active { get; set; }
    public ICollection<OfferMenuItems> OfferMenuItems { get; set; } = new List<OfferMenuItems>();
}