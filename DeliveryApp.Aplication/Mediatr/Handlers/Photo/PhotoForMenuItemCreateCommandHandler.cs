using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class
    PhotoForMenuItemCreateCommandHandler : ICommandHandler<PhotoForMenuItemCreateCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForMenuItemCreateCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoForMenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _photoForMenuItemRepository.AddPhotoForMenuItem(request.File, request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessagesEn.PhotoForMenuItem.PhotoAddedSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}