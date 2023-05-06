using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeliveryApp.Application.Repositories;

public interface IAccountRepository
{
    public Task<bool> Register(RegisterDto registerDto, ModelStateDictionary modelState,
        CancellationToken cancellationToken);

    public Task<List<User>> GetAllUsers(CancellationToken cancellationToken);
    public Task<UserDto> Login(LoginDto loginDto, CancellationToken cancellationToken);
    public Task<User> GetCurrentUser(string username, CancellationToken cancellationToken);

    public Task<bool> EditCurrentUserAddress(UserAddressesForCreation userAddressesForCreation,
        CancellationToken cancellationToken);

    public Task<string> GenerateResetPasswordCode(string email, CancellationToken cancellationToken);
    public Task<string> GetResetPasswordCode(string email, CancellationToken cancellationToken);
    public Task<bool> ModifyUserPassword(string email, string password, CancellationToken cancellationToken);
}