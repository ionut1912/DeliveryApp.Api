using System.Net;
using DeliveryApp.Application.Mediatr.Query.StatisticsQuery;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Web.Controllers
{
    public class StatisticsController:BaseApiController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        [HttpGet("items-count")]
        [ProducesResponseType(typeof(ActionResult<List<MenuItemCountModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MenuItemCountModel>>> GetMenuItemCount()
        {
            var query = new MenuItemsCountQuery();
            return HandleResult(await Mediator.Send(query));
        }
    }
}
