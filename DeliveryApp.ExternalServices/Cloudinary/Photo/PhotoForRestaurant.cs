namespace DeliveryApp.ExternalServices.Cloudinary.Photo;

public class PhotoForRestaurant
{
    public string Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public Guid RestaurantsId { get; set; }
}