using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class UserConfigService : IUserConfigRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public UserConfigService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<UserConfig>> AddConfig(UserConfigCreateCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == command.UserConfigs.Username,
            cancellationToken);
        if (user == null)
            return Result<UserConfig>.Failure($"User with username {command.UserConfigs.Username} does not exists");
        var config = _mapper.Map<UserConfigs>(command.UserConfigs);
        config.Id = Guid.NewGuid();
        config.UserId = user.Id;
        _context.UserConfigs.Add(config);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        var mapped = _mapper.Map<UserConfig>(config);
        return result
            ? Result<UserConfig>.Success(mapped)
            : Result<UserConfig>.Failure(
                "Failed to create user config");
    }

    public async Task<Result<List<UserConfig>>> GetConfigs(ListQuery<UserConfig> command,
        CancellationToken cancellationToken)
    {
        var configs = await _context.UserConfigs
            .ToListAsync(cancellationToken);
        var mapped = _mapper.Map<List<UserConfig>>(configs);
        return Result<List<UserConfig>>.Success(
            mapped);
    }

    public async Task<Result<UserConfig>> GetConfig(QueryItem<UserConfig> query, CancellationToken cancellationToken)
    {
        var config =
            await _context.UserConfigs
                .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
        if (config == null)
            return Result<UserConfig>.Failure(
                "Config not found");
        var mapped = _mapper.Map<UserConfig>(config);

        return Result<UserConfig>.Success(mapped);
    }

    public async Task<Result<UserConfig>> GetConfigByUsername(UserConfigQueryItemByUsername query,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == query.Username, cancellationToken);
        if (user == null) return Result<UserConfig>.Failure($"User with username {query.Username} does not exists");
        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.Username == query.Username, cancellationToken);
        if (config == null) return Result<UserConfig>.Failure("Config not found");
        var mapped = _mapper.Map<UserConfig>(config);
        return Result<UserConfig>.Success(mapped);
    }

    public async Task<Result<Unit>> EditConfig(UserConfigsUpdateCommand command, CancellationToken cancellationToken)
    {
        var configs = await _context.UserConfigs.FindAsync(command.Id);
        if (configs == null) return null;
        _mapper.Map(command.Configs, configs);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update config") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<Unit>> DeleteConfig(DeleteCommand query, CancellationToken cancellationToken)
    {
        var config = await _context.UserConfigs.FindAsync(query.Id);
        if (config == null) return null;
        _context.Remove(config);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to delete config") : Result<Unit>.Success(Unit.Value);
    }
}