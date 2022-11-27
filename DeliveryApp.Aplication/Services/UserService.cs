using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

public class UserService : IUserService
{
    private readonly DeliveryContext _context;

    public UserService(DeliveryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Users> getByEmail(string email)
    {
        var user = await _context.Users.Include(x => x.userAddress).Include(x => x.photos)
            .FirstOrDefaultAsync(x => x.Email == email);
        if (user == null) return null;

        return user;
    }
}