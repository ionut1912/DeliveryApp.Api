using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

public class OfferService : IOfferRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public OfferService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<Offers>> AddOffer(OfferCreateCommand command, CancellationToken cancellationToken)
    {
        var offer = _mapper.Map<Offers>(command.offerForCreation);
        offer.id = Guid.NewGuid();
        var foundMenuItem =
            await _context.MenuItems.FirstOrDefaultAsync(x => x.id == command.offerForCreation.menuItemId,
                cancellationToken);
        if (foundMenuItem == null) return Result<Offers>.Failure("Menu Item not found");

        offer.active = DateTime.Now <= offer.dateActiveTo;

        offer.offerMenuItems.Add(new OfferMenuItems
            { offerId = offer.id, menuItemId = foundMenuItem.id });
        _context.Offers.Add(offer);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Offers>.Failure("Offer not created") : Result<Offers>.Success(offer);
    }

    public async Task<Result<Unit>> EditOffer(OfferEditCommand command, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.FindAsync(command.id);
        if (offer == null) return null;
        offer.active = DateTime.Now <= offer.dateActiveTo;

        _mapper.Map(command.offerForUpdate, offer);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update offer") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<List<Offers>>> GetOffers(ListQuery<Offers> request, CancellationToken cancellationToken)
    {
        return Result<List<Offers>>.Success(await _context.Offers.Include(x => x.offerMenuItems)
            .ToListAsync(cancellationToken));
    }

    public async Task<Result<Offers>> GetOffer(QueryItem<Offers> request, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.Include(x => x.offerMenuItems)
            .FirstOrDefaultAsync(x => x.id == request.id, cancellationToken);
        return offer == null ? Result<Offers>.Failure("Offer not found") : Result<Offers>.Success(offer);
    }
}