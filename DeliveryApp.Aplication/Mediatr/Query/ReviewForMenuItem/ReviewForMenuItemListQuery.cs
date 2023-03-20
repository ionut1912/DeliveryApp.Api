using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem
{
    public class ReviewForMenuItemListQuery:ListQuery<Domain.Models.ReviewForMenuItem>
    {
        public Guid MenuItemId { get; set; }
    }
}
