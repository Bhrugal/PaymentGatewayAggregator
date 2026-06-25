namespace PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

public class UpdateMerchantRequest
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string GatewayType { get; set; } = string.Empty;
}