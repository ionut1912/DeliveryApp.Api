using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Repository.Entities;

public class MenuItems
{
    public Guid id { get; set; }
    public string itemName { get; set; }
    public string category { get; set; }
    public string ingredients { get; set; }
    public float price { get; set; }
    public int quantity { get; set; }
    public bool active { get; set; }
    public ICollection<OfferMenuItems> offerMenuItems { get; set; }

    public ICollection<PhotoForMenuItem> Photos { get; set; } =
        new List<PhotoForMenuItem>();
}