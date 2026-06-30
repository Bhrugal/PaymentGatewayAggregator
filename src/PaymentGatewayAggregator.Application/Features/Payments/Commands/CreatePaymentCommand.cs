using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Payments.Commands;

public class CreatePaymentCommand : IRequest<CreatePaymentResponse>
{
    public Guid MerchantId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;
}