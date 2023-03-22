﻿using AutoMapper;
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
            foreach (var error in result.Errors) modelState.AddModelError(error.Code, error.Description);

            return false;
        }

        await _userManager.AddToRoleAsync(user, "Member");
        return true;
    }

    public async Task<UserDto> Login(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.AsNoTracking().Include(x => x.UserAddress).Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.UserName == loginDto.Username, cancellationToken);

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

    public async Task<UserDto> GetCurrentUser(string username, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .Include(x => x.Photos)
            .Include(x => x.UserAddress)
            .Include(x => x.UserConfigs)
            .FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);

        return new UserDto

        {
            PhoneNumber = user.PhoneNumber,
            Token = await _tokenService.GenerateToken(user),
            Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            Username = user.UserName,
            Email = user.Email,
            Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress),
            UserConfig = _mapper.Map<UserConfig>(user.UserConfigs)
        };
    }

    public async Task<bool> EditCurrentUser(UserDto userToBeEdited, ModelStateDictionary modelState,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .Include(x => x.Photos)
            .Include(x => x.UserAddress)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.PhoneNumber = userToBeEdited.PhoneNumber ?? user.PhoneNumber;
        user.UserName = userToBeEdited.Username ?? user.UserName;

        user.Email = userToBeEdited.Email ?? user.Email;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) modelState.AddModelError(error.Code, error.Description);

            return false;
        }

        return true;
    }

    public async Task<bool> EditCurrentUserAddress(UserAddressesForCreation userAddressesForCreation,
        CancellationToken cancellationToken)
    {
        var user = await _deliveryContext.Users
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
}