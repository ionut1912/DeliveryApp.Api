using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Commons.Query;

public class QueryItem<T> : IQuery<Result<T>>
{
    public Guid id { get; set; }
}