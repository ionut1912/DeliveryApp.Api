using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Repository.Context;

namespace DeliveryApp.Repository.Services
{
    public class UnitOfWork:IUnitOfWork
    {
        private  readonly DeliveryContext _deliveryContext;

        public UnitOfWork(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          return  _deliveryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
