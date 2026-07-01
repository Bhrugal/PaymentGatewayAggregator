using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Payments.Queries;

public class GetPaymentByIdQuery : IRequest<PaymentDto?>
{
    public Guid Id { get; set; }

    public GetPaymentByIdQuery(Guid id)
    {
        Id = id;
    }
}