using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories
{
    public interface IStatisticsRepository
    {
        Task<List<MenuItemCountModel>> GetMenuItemCount(CancellationToken cancellationToken);
    }
}
