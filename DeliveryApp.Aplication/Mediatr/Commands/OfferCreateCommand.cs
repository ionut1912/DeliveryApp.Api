using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Commands
{
    public class OfferCreateCommand : ICommand<Result<Offers>>
    {
        public OfferForCreation offerForCreation { get; set; }
    }
}
