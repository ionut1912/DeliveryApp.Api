﻿using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.Cloudinary.Photo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers
{
    [AllowAnonymous]
    public class PhotoControllerForMenuItems : BaseApiController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        [Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<PhotoForMenuItem>> AddPhoto(IFormFile file, Guid id)
        {
            return HandleResult(
                await Mediator.Send(new PhotoForMenuItemCreateCommand { file = file, id = id }));
        }

        [Authorize]
        [HttpDelete("{photoId}/{itemId}")]
        public async Task<ActionResult<PhotoForMenuItem>> Delete(string photoId, Guid itemId)
        {
            return HandleResult(
                await Mediator.Send(new PhotoForMenuItemDeleteCommand { photoId = photoId, itemId = itemId }));
        }

        [Authorize]
        [HttpPost("{photoId}/{itemId}/setMain")]
        public async Task<ActionResult<PhotoForMenuItem>> SetMain(string photoId, Guid itemId)
        {
            return HandleResult(
                await Mediator.Send(new PhotoForMenuItemDeleteCommand { photoId = photoId, itemId = itemId }));
        }
    }
}
