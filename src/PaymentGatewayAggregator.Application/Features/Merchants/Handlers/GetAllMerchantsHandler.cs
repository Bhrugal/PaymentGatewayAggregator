using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Application.Features.Merchants.Queries;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Application.Mappings;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class GetAllMerchantsHandler
    : IRequestHandler<GetAllMerchantsQuery, List<MerchantDto>>
{
    private readonly IMerchantRepository _repository;

    public GetAllMerchantsHandler(IMerchantRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MerchantDto>> Handle(
        GetAllMerchantsQuery request,
        CancellationToken cancellationToken)
    {
        var merchants = await _repository.GetAllAsync();

        return merchants
            .Select(x => x.ToDto())
            .ToList();
    }
}