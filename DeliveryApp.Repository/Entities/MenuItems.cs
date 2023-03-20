using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Repository.Entities;

public class MenuItems
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public bool Active { get; set; }
    public ICollection<OfferMenuItems> OfferMenuItems { get; set; }

    public ICollection<PhotoForMenuItem> Photos { get; set; } =
        new List<PhotoForMenuItem>();

    public ICollection<ReviewForMenuItems> Reviews { get; set; } = new List<ReviewForMenuItems>();
}