using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeliveryApp.Application.Repositories;

public interface IAccountRepository
{
    public Task<bool> Register(RegisterDto registerDto, ModelStateDictionary modelState,
        CancellationToken cancellationToken);

    public Task<UserDto> Login(LoginDto loginDto, CancellationToken cancellationToken);
    public Task<UserDto> GetCurrentUser(string username, CancellationToken cancellationToken);

    public Task<bool> EditCurrentUser(UserDto userToBeEdited, ModelStateDictionary modelState,
        CancellationToken cancellationToken);

    public Task<bool> EditCurrentUserAddress(UserAddressesForCreation userAddressesForCreation,
        CancellationToken cancellationToken);
}