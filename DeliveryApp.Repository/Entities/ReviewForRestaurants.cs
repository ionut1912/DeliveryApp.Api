namespace DeliveryApp.Repository.Entities
{
    public class ReviewForRestaurants
    {
        public Guid Id { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public Users User { get; set; }
        public Guid RestaurantId{ get; set; }
    }
}
