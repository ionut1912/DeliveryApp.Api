namespace DeliveryApp.ExternalServices.Cloudinary.Photo;

public class PhotoForMenuItem
{
    public string Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public Guid MenuItemsid { get; set; }
}