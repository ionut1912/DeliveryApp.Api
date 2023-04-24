using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.ExternalServices.MailSending;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class AccountRepository : IAccountRepository
{
    private readonly DeliveryContext _deliveryContext;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly TokenService _tokenService;
    private readonly IUserAccessor _userAccessor;
    private readonly UserManager<Users> _userManager;

    public AccountRepository(IMailService mailService, IMapper mapper, TokenService tokenService,
        UserManager<Users> userManager, IUserAccessor userAccessor, DeliveryContext deliveryContext)
    {
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
    }


    public async Task<bool> Register(RegisterDto registerDto, ModelStateDictionary modelState,
        CancellationToken cancellationToken)
    {
        var address = _mapper.Map<UserAddresses>(registerDto.AddressForCreation);
        address.AddressId = Guid.NewGuid();
        var user = new Users
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
            UserAddress = address,
            PhoneNumber = registerDto.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            AddErrorToModelState(result, modelState);
            return false;
        }

        await _userManager.AddToRoleAsync(user, "Member");
        return true;
    }

    public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = new List<User>();
        var users = await _userManager.Users.Include(x => x.UserAddress).Include(x=>x.Orders).Include(x => x.UserConfigs)
            .Include(x => x.Photos).AsNoTracking().ToListAsync(cancellationToken);
        foreach (var user in users)
        {
            var responseUser = new User
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress),
                UserConfig = _mapper.Map<UserConfig>(user.UserConfigs),
                PhoneNumber = user.PhoneNumber,
                Photos = user.Photos.Select(x => x.Url).ToList(),
                Role = await GetUserRole(user, cancellationToken),
                OrdersCount = user.Orders.Count()
            };
            response.Add(responseUser);
        }

        return response;
    }

    public async Task<UserDto> Login(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Include(x => x.UserAddress).Include(x => x.Photos)
            .AsNoTracking().FirstOrDefaultAsync(x => x.UserName == loginDto.Username, cancellationToken);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            throw new Exception("User not found or incorrect password");
        var request = new WelcomeRequest
        {
            ToEmail = loginDto.Email,
            UserName = loginDto.Username
        };

        await _mailService.SendWelcomeEmailAsync(request);
        return new UserDto

        {
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Token = await _tokenService.GenerateToken(user),
            Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            Username = user.UserName,
            Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress)
        };
    }

    public async Task<User> GetCurrentUser(string username, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .Include(x => x.Photos)
            .Include(x => x.UserAddress)
            .Include(x => x.UserConfigs)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);

        return new User

        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            Photos = user.Photos.Select(x => x.Url).ToList(),
            Username = user.UserName,
            Email = user.Email,
            Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress),
            UserConfig = _mapper.Map<UserConfig>(user.UserConfigs),
            Role = await GetUserRole(user, cancellationToken)
        };
    }

    public async Task<EditCurrentUserResponse> EditCurrentUser(UserDto userToBeEdited, ModelStateDictionary modelState,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .Include(x => x.Photos)
            .Include(x => x.UserAddress)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.PhoneNumber = userToBeEdited.PhoneNumber ?? user.PhoneNumber;
        user.UserName = userToBeEdited.Username ?? user.UserName;

        user.Email = userToBeEdited.Email ?? user.Email;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            AddErrorToModelState(result, modelState);
            return new EditCurrentUserResponse();
        }

        var response = new EditCurrentUserResponse
        {
            Email = user.Email,
            Token = await _tokenService.GenerateToken(user)
        };
        return response;
    }

    public async Task<bool> EditCurrentUserAddress(UserAddressesForCreation userAddressesForCreation,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        if (user == null) return false;
        var address = await _deliveryContext.UserAddresses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken);
        if (address == null) return false;

        var addressToBeModified = _mapper.Map(userAddressesForCreation, address);
        _deliveryContext.UserAddresses.Update(addressToBeModified);
        return true;
    }


    private async Task<string> GetUserRole(Users user, CancellationToken cancellationToken)
    {
        var roleId = await _deliveryContext.UserRoles.AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken);
        var role = await _deliveryContext.Roles.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == roleId.RoleId, cancellationToken);
        return role.Name;
    }

    private static void AddErrorToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
    {
        foreach (var error in identityResult.Errors) modelState.AddModelError(error.Code, error.Description);
    }
}