using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Contracts
{
    public class CurrentUserReviewForRestaurant
    {
        public  Guid Id { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set;}
        public  int NumberOfStars { get; set; }
        public string Username { get; set; }
        public  string RestaurantName { get; set; }
    }
}
