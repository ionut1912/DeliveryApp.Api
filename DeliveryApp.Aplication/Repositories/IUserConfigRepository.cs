using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IUserConfigRepository
{
    Task<Result<UserConfigs>> AddConfig(UserConfigCreateCommand command, CancellationToken cancellationToken);
    Task<Result<List<UserConfigs>>> GetConfigs(ListQuery<UserConfigs> command, CancellationToken cancellationToken);
    Task<Result<UserConfigs>> GetConfig(QueryItem<UserConfigs> query, CancellationToken cancellationToken);

    Task<Result<UserConfigs>> GetConfigByUsername(UserConfigQueryItemByUsername query,
        CancellationToken cancellationToken);

    Task<Result<Unit>> EditConfig(UserConfigsUpdateCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteConfig(DeleteCommand query, CancellationToken cancellationToken);
}