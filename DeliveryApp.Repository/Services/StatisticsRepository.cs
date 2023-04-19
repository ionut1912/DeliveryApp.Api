using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services
{
   public class StatisticsRepository:IStatisticsRepository
   {
       private readonly DeliveryContext _deliveryContext;

       public StatisticsRepository(DeliveryContext deliveryContext)
       {
           _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
       }

       public async Task<List<MenuItemCountModel>> GetMenuItemCount(CancellationToken cancellationToken)
       {
           var menuItems = await _deliveryContext.MenuItems.AsNoTracking().ToListAsync(cancellationToken);

           return menuItems.Select(menuItem => new MenuItemCountModel { MenuItemName = menuItem.ItemName, MenuItemCount = menuItem.Quantity }).ToList();

       }
    }
}
