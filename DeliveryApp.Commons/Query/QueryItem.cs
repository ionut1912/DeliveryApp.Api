using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Commons.Query;

public class QueryItem<T> : IQuery<ResultT<T>>
{
    public Guid Id { get; set; }
}