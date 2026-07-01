using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Payments.Commands;

public class UpdatePaymentCommand : IRequest<PaymentDto?>
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}