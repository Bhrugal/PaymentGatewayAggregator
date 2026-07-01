using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Payments.Queries;

public class GetAllPaymentsQuery : IRequest<List<PaymentDto>>
{
}