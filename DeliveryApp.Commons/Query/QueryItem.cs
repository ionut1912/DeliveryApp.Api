using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Commons.Query
{
    public class QueryItem<T>:IQuery<Result<T>>
    {
        public  Guid id { get; set; }
    }
}
