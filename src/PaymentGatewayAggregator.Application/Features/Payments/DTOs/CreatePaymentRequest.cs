namespace PaymentGatewayAggregator.Application.Features.Payments.DTOs;

public class CreatePaymentRequest
{
    public Guid MerchantId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;
}