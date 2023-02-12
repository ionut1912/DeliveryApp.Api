﻿using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class
    PhotoForMenuItemCreateCommandHandler : ICommandHandler<PhotoForMenuItemCreateCommand, ResultT<PhotoForMenuItem>>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;

    public PhotoForMenuItemCreateCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
    }

    public async Task<ResultT<PhotoForMenuItem>> Handle(PhotoForMenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        return await _photoForMenuItemRepository.AddPhotoForMenuItem(request, cancellationToken);
    }
}