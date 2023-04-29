using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class EditOrderRequest
{
    public string Language { get; set; }
    public OrderForUpdateDto OrderForUpdate { get; set; }
}