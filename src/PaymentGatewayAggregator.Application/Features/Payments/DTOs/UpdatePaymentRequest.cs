namespace PaymentGatewayAggregator.Application.Features.Payments.DTOs;

public class UpdatePaymentRequest
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}