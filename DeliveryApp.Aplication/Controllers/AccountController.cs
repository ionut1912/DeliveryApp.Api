using AutoMapper;
using DeliveryApp.Aplication.MailSending;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Aplication.Services;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.MailSender;
using DeliveryApp.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Controllers;

[AllowAnonymous]
[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly SignInManager<Users> _signInManager;
    private readonly TokenService _tokenService;
    private readonly UserManager<Users> _userManager;
    private readonly IUserService _userService;

    public AccountController(IMapper mapper, SignInManager<Users> signInManager, TokenService tokenService,
        UserManager<Users> userManager, IUserService userService, IMailService mailService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.Include(p => p.photos).Include(p => p.userAddress)
            .FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        if (user == null) return Unauthorized();
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) return Unauthorized();
        var request = new WelcomeRequest
        {
            ToEmail = loginDto.Email,
            UserName = loginDto.Username
        };
        await _mailService.SendWelcomeEmailAsync(request);

        return new UserDto

        {
            token = await _tokenService.GenerateToken(user),
            image = user.photos.FirstOrDefault(x => x.IsMain)?.Url,
            username = user.UserName,
            address = _mapper.Map<UserAddressesForCreation>(user.userAddress)
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
        {
            ModelState.AddModelError("email", "Email taken");
            return ValidationProblem();
        }

        if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
        {
            ModelState.AddModelError("username", "Username taken");
            return ValidationProblem();
        }

        var address = _mapper.Map<UserAddresses>(registerDto.addressForCreation);
        address.addressId = Guid.NewGuid();
        var user = new Users
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
            userAddress = address
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        await _userManager.AddToRoleAsync(user, "Member");

        if (result.Succeeded)
            return new UserDto

            {
                token = await _tokenService.GenerateToken(user),
                image = user.photos.FirstOrDefault(x => x.IsMain)?.Url,
                username = user.UserName,
                address = _mapper.Map<UserAddressesForCreation>(user.userAddress)
            };
        return BadRequest("Problems registering user");
    }

    [Authorize]
    [HttpGet("{email}")]
    public async Task<ActionResult<UserDto>> GetCurrentUser(string email)
    {
        var user = await _userService.getByEmail(email);
        return new UserDto

        {
            token = await _tokenService.GenerateToken(user),
            image = user.photos.FirstOrDefault(x => x.IsMain)?.Url,
            username = user.UserName,
            address = _mapper.Map<UserAddressesForCreation>(user.userAddress)
        };
    }
}