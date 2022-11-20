namespace DeliveryApp.Repository.Entities
{
    public class Offers
    {
        public Guid id { get; set; }
        public DateTime dateActiveFrom { get; set; }
        public DateTime dateActiveTo { get; set; }
        public int discount { get; set; }
        public bool active { get; set; }
        public ICollection<OfferMenuItems> offerMenuItems { get; set; } = new List<OfferMenuItems>();
    }
}
