﻿using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantQueryItemHandler : IQueryHandler<
    QueryItem<Domain.Models.RestaurantWithImages>,
    ResultT<Domain.Models.RestaurantWithImages>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantQueryItemHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<Domain.Models.RestaurantWithImages>> Handle(
        QueryItem<Domain.Models.RestaurantWithImages> request,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.GetRestaurant(request.Id, cancellationToken);
        if (result == null)
            return ResultT<Domain.Models.RestaurantWithImages>.Failure(DomainMessages.Restaurant.NotFoundRestaurant(request.Id));
        return ResultT<Domain.Models.RestaurantWithImages>.Success(result);
    }
}