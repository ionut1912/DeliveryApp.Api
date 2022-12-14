using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

public class UserConfigService : IUserConfigRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public UserConfigService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<UserConfigs>> AddConfig(UserConfigCreateCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == command.userConfigs.username,
            cancellationToken);
        if (user == null)
            return Result<UserConfigs>.Failure($"User with username {command.userConfigs.username} does not exists");
        var config = _mapper.Map<UserConfigs>(command.userConfigs);
        config.id = Guid.NewGuid();
        config.userId = user.Id;
        _context.UserConfigs.Add(config);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return result
            ? Result<UserConfigs>.Success(config)
            : Result<UserConfigs>.Failure(
                "Failed to create user config");
    }

    public async Task<Result<List<UserConfigs>>> GetConfigs(ListQuery<UserConfigs> command,
        CancellationToken cancellationToken)
    {
        return Result<List<UserConfigs>>.Success(
            await _context.UserConfigs
                .ToListAsync(cancellationToken));
    }

    public async Task<Result<UserConfigs>> GetConfig(QueryItem<UserConfigs> query, CancellationToken cancellationToken)
    {
        var config =
            await _context.UserConfigs
                .FirstOrDefaultAsync(x => x.id == query.id, cancellationToken);
        if (config == null)
            return Result<UserConfigs>.Failure(
                "Config not found");

        return Result<UserConfigs>.Success(config);
    }

    public async Task<Result<UserConfigs>> GetConfigByUsername(UserConfigQueryItemByUsername query,
        CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefaultAsync(x => x.UserName == query.username, cancellationToken);
        if (user == null) return Result<UserConfigs>.Failure($"User with username {query.username} does not exists");
        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.username == query.username, cancellationToken);
        if (config == null) return Result<UserConfigs>.Failure("Config not found");
        return Result<UserConfigs>.Success(config);
    }

    public async Task<Result<Unit>> EditConfig(UserConfigsUpdateCommand command, CancellationToken cancellationToken)
    {
        var configs = await _context.UserConfigs.FindAsync(command.id);
        if (configs == null) return null;
        _mapper.Map(command.configs, configs);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update config") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<Unit>> DeleteConfig(DeleteCommand query, CancellationToken cancellationToken)
    {
        var config = await _context.UserConfigs.FindAsync(query.id);
        if (config == null) return null;
        _context.Remove(config);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to delete config") : Result<Unit>.Success(Unit.Value);
    }
}