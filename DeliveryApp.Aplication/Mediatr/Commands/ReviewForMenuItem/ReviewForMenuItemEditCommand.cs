using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem
{
    public class ReviewForMenuItemEditCommand : ICommand<Result>
    {
        public  Guid Id { get; set; }   
        public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
    }
}
