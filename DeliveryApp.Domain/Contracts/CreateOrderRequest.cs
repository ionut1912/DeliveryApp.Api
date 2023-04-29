using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class CreateOrderRequest
{
    public string Language { get; set; }
    public OrderForCreationDto Order { get; set; }
}