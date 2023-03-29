using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
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


    public async Task AddOffer(OfferDto offerDto, CancellationToken cancellationToken)
    {
        var offer = _mapper.Map<Offers>(offerDto);
        offer.Id = Guid.NewGuid();
        var foundMenuItem =
            await _context.MenuItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == offerDto.MenuItemId,
                cancellationToken);

        offer.Active = DateTime.Now <= offer.DateActiveTo;

        offer.OfferMenuItems.Add(new OfferMenuItems
            { OfferId = offer.Id, MenuItemId = foundMenuItem.Id });
        await _context.Offers.AddAsync(offer,cancellationToken);
    }

    public async Task<bool> EditOffer(Guid id, OfferDto offerDto, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.FindAsync(id);
        if (offer == null) return false;
        var modifiedOffer = _mapper.Map(offerDto, offer);
        modifiedOffer.Active = DateTime.Now <= offer.DateActiveTo;
        _context.Offers.Update(modifiedOffer);
        return true;
    }

    public async Task<List<Offer>> GetOffers(CancellationToken cancellationToken)
    {
        var offers = await _context.Offers.Include(x => x.OfferMenuItems)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<Offer>>(offers);
    }

    public async Task<Offer> GetOffer(Guid id, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<Offer>(offer);
    }
}