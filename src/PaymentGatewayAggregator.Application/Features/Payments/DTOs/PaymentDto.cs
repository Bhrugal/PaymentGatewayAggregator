namespace PaymentGatewayAggregator.Application.Features.Payments.DTOs;

public class PaymentDto
{
    public Guid Id { get; set; }

    public Guid MerchantId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}