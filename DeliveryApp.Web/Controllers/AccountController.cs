using AutoMapper;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.ExternalServices.MailSending;
using DeliveryApp.Repository.Entities;
using DeliveryApp.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly TokenService _tokenService;
    private readonly UserManager<Users> _userManager;

    public AccountController(IMapper mapper, TokenService tokenService,
        UserManager<Users> userManager, IMailService mailService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.Include(x => x.UserAddress).Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            return Unauthorized();
        var request = new WelcomeRequest
        {
            ToEmail = loginDto.Email,
            UserName = loginDto.Username
        };
        await _mailService.SendWelcomeEmailAsync(request);
        return new UserDto

        {
            Token = await _tokenService.GenerateToken(user),
            Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            Username = user.UserName,
            Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress)
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var address = _mapper.Map<UserAddresses>(registerDto.AddressForCreation);
        address.AddressId = Guid.NewGuid();
        var user = new Users
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
            UserAddress = address
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(error.Code, error.Description);

            return ValidationProblem();
        }

        await _userManager.AddToRoleAsync(user, "Member");

        return StatusCode(201);
    }


    [Authorize]
    [HttpGet("current")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.Users.Include(x => x.Photos).Include(x => x.UserAddress)
            .FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
        return new UserDto

        {
            Token = await _tokenService.GenerateToken(user),
            Image = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
            Username = user.UserName,
            Address = _mapper.Map<UserAddressesForCreation>(user.UserAddress)
        };
    }
}