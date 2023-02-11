using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class OfferService : IOfferRepository
{
    private readonly DeliveryContext _context;
    private readonly IMapper _mapper;

    public OfferService(DeliveryContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

    public async Task<Result<Offer>> AddOffer(OfferCreateCommand command, CancellationToken cancellationToken)
    {
        var offer = _mapper.Map<Offers>(command.OfferForCreation);
        offer.Id = Guid.NewGuid();
        var foundMenuItem =
            await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == command.OfferForCreation.MenuItemId,
                cancellationToken);
        if (foundMenuItem == null) return Result<Offer>.Failure("Menu Item not found");

        offer.Active = DateTime.Now <= offer.DateActiveTo;

        offer.OfferMenuItems.Add(new OfferMenuItems
            { OfferId = offer.Id, MenuItemId = foundMenuItem.Id });
        _context.Offers.Add(offer);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        var mapped = _mapper.Map<Offer>(offer);
        return !result ? Result<Offer>.Failure("Offer not created") : Result<Offer>.Success(mapped);
    }

    public async Task<Result<List<Offer>>> GetOffers(ListQuery<Offer> request, CancellationToken cancellationToken)
    {
        var offers = await _context.Offers.Include(x => x.OfferMenuItems)
            .ToListAsync(cancellationToken);
        var mapped = _mapper.Map < List<Offer> > (offers);
        return Result<List<Offer>>.Success(mapped);
    }

    public async Task<Result<Offer>> GetOffer(QueryItem<Offer> request, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        var mapped= _mapper.Map<Offer>(offer);
        return offer == null ? Result<Offer>.Failure("Offer not found") : Result<Offer>.Success(mapped);
    }
}