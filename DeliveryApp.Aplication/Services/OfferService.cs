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
        var offer = _mapper.Map<Offers>(command.OfferForCreation);
        offer.Id = Guid.NewGuid();
        var foundMenuItem =
            await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == command.OfferForCreation.MenuItemId,
                cancellationToken);
        if (foundMenuItem == null) return Result<Offers>.Failure("Menu Item not found");

        offer.Active = DateTime.Now <= offer.DateActiveTo;

        offer.OfferMenuItems.Add(new OfferMenuItems
            { OfferId = offer.Id, MenuItemId = foundMenuItem.Id });
        _context.Offers.Add(offer);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Offers>.Failure("Offer not created") : Result<Offers>.Success(offer);
    }

    public async Task<Result<Unit>> EditOffer(OfferEditCommand command, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.FindAsync(command.Id);
        if (offer == null) return null;
        offer.Active = DateTime.Now <= offer.DateActiveTo;

        _mapper.Map(command.OfferForUpdate, offer);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return !result ? Result<Unit>.Failure("Failed to update offer") : Result<Unit>.Success(Unit.Value);
    }

    public async Task<Result<List<Offers>>> GetOffers(ListQuery<Offers> request, CancellationToken cancellationToken)
    {
        return Result<List<Offers>>.Success(await _context.Offers.Include(x => x.OfferMenuItems)
            .ToListAsync(cancellationToken));
    }

    public async Task<Result<Offers>> GetOffer(QueryItem<Offers> request, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return offer == null ? Result<Offers>.Failure("Offer not found") : Result<Offers>.Success(offer);
    }
}