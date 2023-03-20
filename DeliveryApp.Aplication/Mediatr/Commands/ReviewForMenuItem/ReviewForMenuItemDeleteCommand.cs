using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Commons.Commands;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem
{
    public class ReviewForMenuItemDeleteCommand : DeleteCommand

    {
        public  Guid MenuItemId { get; set; }
    }
}
