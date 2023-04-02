using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(
            x => x.UserName == _userAccessor.GetUsername(),
            cancellationToken);
        if (user == null) return false;
        var config = _mapper.Map<UserConfigs>(userConfigDto);
        config.Id = Guid.NewGuid();
        config.UserId = user.Id;
        config.Username = user.UserName;
        double bmr = 0;

        if (config.Sex == "Male")
            bmr = 88.36 + 13.4 * config.Weight + 4.8 * config.Height - 5.7 * config.Age;
        else
            bmr = 447.6 + 9.2 * config.Weight + 3.1 * config.Height - 4.3 * config.Age;

        config.NumberOfCaloriesAllowed = CalculateNumberOfCalories(userConfigDto.SportActivity, bmr);

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
            await _context.UserConfigs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<UserConfig>(config);
    }

    public async Task<UserConfig> GetConfigByUsername(CancellationToken cancellationToken)

    {
        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.Username == _userAccessor.GetUsername(),
                cancellationToken);

        return _mapper.Map<UserConfig>(config);
    }

    public async Task<bool> EditConfig(Guid id, UserConfigDto userConfigDto, CancellationToken cancellationToken)

    {
      
        var config =
            await _context.UserConfigs.FirstOrDefaultAsync(x => x.Username == _userAccessor.GetUsername(),
                cancellationToken);
        if (config == null) return false;
        var modifiedConfig = _mapper.Map(userConfigDto, config);
        double bmr = 0;

        if (config.Sex == "Male")
            bmr = 88.36 + 13.4 * config.Weight + 4.8 * config.Height - 5.7 * config.Age;
        else
            bmr = 447.6 + 9.2 * config.Weight + 3.1 * config.Height - 4.3 * config.Age;

        config.NumberOfCaloriesAllowed = CalculateNumberOfCalories(userConfigDto.SportActivity, bmr);

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

    private double CalculateNumberOfCalories(int sportActivity,double bmr)
    {
        return sportActivity switch
        {
            0 => bmr * 1.2,
            >= 1 and < 3 => bmr * 1.375,
            >= 3 and <= 5 => bmr * 1.55,
            _ => bmr * 1.725
        };
    }
}