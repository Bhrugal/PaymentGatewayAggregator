namespace PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

public class CreateMerchantRequest
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public object GatewayType { get; set; }
}