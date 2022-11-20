using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{

    public class RestaurantQueryItemHandler : IQueryHandler<
        QueryItem<Restaurants>,
        Result<Restaurants>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantQueryItemHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        }

        public async Task<Result<Restaurants>> Handle(
            QueryItem<Restaurants> request,
            CancellationToken cancellationToken)
        {
            return await _restaurantRepository.GetRestaurant(request, cancellationToken);
        }
    }
}
