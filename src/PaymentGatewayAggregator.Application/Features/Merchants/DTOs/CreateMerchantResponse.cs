namespace PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

public class CreateMerchantResponse
{
    public Guid MerchantId { get; set; }

    public string Message { get; set; } = string.Empty;
}