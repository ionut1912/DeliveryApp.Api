﻿using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IUserConfigRepository
{
    Task<bool> AddConfig(UserConfigDto userConfigDto, CancellationToken cancellationToken);
    Task<List<UserConfig>> GetConfigs(CancellationToken cancellationToken);
    Task<UserConfig> GetConfig(Guid id, CancellationToken cancellationToken);

    Task<UserConfig> GetConfigByUsername(
        CancellationToken cancellationToken);

    Task<bool> EditConfig(Guid id, UserConfigDto userConfigDto, CancellationToken cancellationToken);
    Task<bool> DeleteConfig(Guid id, CancellationToken cancellationToken);
}