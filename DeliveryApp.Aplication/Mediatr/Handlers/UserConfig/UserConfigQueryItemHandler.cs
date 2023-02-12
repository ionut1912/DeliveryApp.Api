﻿using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.UserConfig;

public class
    UserConfigQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.UserConfigDto>, ResultT<Domain.Models.UserConfigDto>>
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigQueryItemHandler(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository ?? throw new ArgumentNullException(nameof(userConfigRepository));
    }

    public async Task<ResultT<Domain.Models.UserConfigDto>> Handle(QueryItem<Domain.Models.UserConfigDto> request,
        CancellationToken cancellationToken)
    {
        return await _userConfigRepository.GetConfig(request, cancellationToken);
    }
}