//namespace PaymentGatewayAggregator.Application.Features.Merchants.Queries;

//public class GetMerchantByIdQuery
//{
//    public Guid MerchantId { get; set; }
//}


using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Queries;

public class GetMerchantByIdQuery : IRequest<MerchantDto?>
{
    public Guid Id { get; set; }

    public GetMerchantByIdQuery(Guid id)
    {
        Id = id;
    }
}