using AutoMapper;
using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == offerDto.MenuItemId,
                cancellationToken);

        offer.Active = DateTime.Now <= offer.DateActiveTo;

        offer.OfferMenuItems.Add(new OfferMenuItems
            { OfferId = offer.Id, MenuItemId = foundMenuItem.Id }); 
        await _context.Offers.AddAsync(offer);
      
    }

    public async Task<bool> EditOffer(Guid id,OfferDto offerDto, CancellationToken cancellationToken)
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
        return  _mapper.Map<List<Offer>>(offers);
        
    }

    public async Task<Offer> GetOffer(Guid id, CancellationToken cancellationToken)
    {
        var offer = await _context.Offers.Include(x => x.OfferMenuItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<Offer>(offer);
    }
}