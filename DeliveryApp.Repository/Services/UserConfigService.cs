using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class UserConfigService : IUserConfigRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public UserConfigService(DeliveryContext context, IMapper mapper, IUserAccessor userAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
    }

    public async Task<bool> AddConfig(UserConfigDto userConfigDto, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(),
            cancellationToken);
        if (user == null) return false;
        var config = _mapper.Map<UserConfigs>(userConfigDto);
        config.Id = Guid.NewGuid();
        config.UserId = user.Id;
        config.Username = user.UserName;
        await _context.UserConfigs.AddAsync(config, cancellationToken);
        return true;
    }

    public async Task<List<UserConfig>> GetConfigs(CancellationToken cancellationToken)
    {
        var configs = await _context.UserConfigs
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<UserConfig>>(configs);
    }

    public async Task<UserConfig> GetConfig(Guid id, CancellationToken cancellationToken)
    {
        var config =
            await _context.UserConfigs
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<UserConfig>(config);
    }

    public async Task<UserConfig> GetConfigByUsername(CancellationToken cancellationToken)

    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(),
            cancellationToken);

        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.Username == _userAccessor.GetUsername(),
                cancellationToken);

        return _mapper.Map<UserConfig>(config);
    }

    public async Task<bool> EditConfig(Guid id, UserConfigDto userConfigDto, CancellationToken cancellationToken)

    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(),
            cancellationToken);
        if (user == null) return false;
        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.Username == _userAccessor.GetUsername(),
                cancellationToken);
        if (config == null) return false;
        var modifiedConfig = _mapper.Map(userConfigDto, config);
        _context.UserConfigs.Update(modifiedConfig);
        return true;
    }

    public async Task<bool> DeleteConfig(Guid id, CancellationToken cancellationToken)
    {
        var config = await _context.UserConfigs.FindAsync(id);
        if (config == null) return false;
        _context.Remove(config);
        return true;
    }
}