using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IUserConfigRepository
{
    Task<Result<UserConfig>> AddConfig(UserConfigCreateCommand command, CancellationToken cancellationToken);
    Task<Result<List<UserConfig>>> GetConfigs(ListQuery<UserConfig> command, CancellationToken cancellationToken);
    Task<Result<UserConfig>> GetConfig(QueryItem<UserConfig> query, CancellationToken cancellationToken);

    Task<Result<UserConfig>> GetConfigByUsername(UserConfigQueryItemByUsername query,
        CancellationToken cancellationToken);

    Task<Result<Unit>> EditConfig(UserConfigsUpdateCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteConfig(DeleteCommand query, CancellationToken cancellationToken);
}