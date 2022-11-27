using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Repositories;

public interface IUserService
{
    Task<Users> getByEmail(string email);
}