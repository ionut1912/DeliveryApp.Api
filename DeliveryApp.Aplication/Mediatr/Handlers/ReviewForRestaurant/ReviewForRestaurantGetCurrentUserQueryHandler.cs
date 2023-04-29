using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant
{
    public class ReviewForRestaurantGetCurrentUserQueryHandler:IQueryHandler<ReviewForRestaurantGetCurrentUserQuery,ResultT<List<CurrentUserReviewForRestaurant>>>
    {
        private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;

        public ReviewForRestaurantGetCurrentUserQueryHandler(
            IReviewForRestaurantRepository reviewForRestaurantRepository)
        {
            _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                             throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
        }

        public async Task<ResultT<List<CurrentUserReviewForRestaurant>>> Handle(ReviewForRestaurantGetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _reviewForRestaurantRepository.GetReviewsForRestaurantForCurrentUser(cancellationToken);
            return ResultT<List<CurrentUserReviewForRestaurant>>.Success(result);
        }
    }
}
