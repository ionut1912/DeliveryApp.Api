using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;
using MediatR;

namespace DeliveryApp.Aplication.Repositories
{
    public interface IOfferRepository
    {
        Task<Result<Offers>> AddOffer(OfferCreateCommand command, CancellationToken cancellationToken);
        Task<Result<Unit>> EditOffer(OfferEditCommand command, CancellationToken cancellationToken);

        Task<Result<List<Offers>>> GetOffers(ListQuery<Offers> request,
            CancellationToken cancellationToken);

        Task<Result<Offers>> GetOffer(QueryItem<Offers> request, CancellationToken cancellationToken
        );
    }
}
