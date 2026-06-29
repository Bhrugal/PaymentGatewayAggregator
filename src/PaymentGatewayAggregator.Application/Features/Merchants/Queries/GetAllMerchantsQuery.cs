using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Queries;

public class GetAllMerchantsQuery : IRequest<List<MerchantDto>>
{
}