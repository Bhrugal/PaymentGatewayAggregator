namespace PaymentGatewayAggregator.Application.Features.Payments.DTOs;

public class CreatePaymentResponse
{
    public Guid Id { get; set; }

    public string Status { get; set; } = string.Empty;
}