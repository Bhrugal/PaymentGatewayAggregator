using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Application.Features.Merchants.Queries;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Application.Mappings;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class GetMerchantByIdHandler
    : IRequestHandler<GetMerchantByIdQuery, MerchantDto?>
{
    private readonly IMerchantRepository _repository;

    public GetMerchantByIdHandler(IMerchantRepository repository)
    {
        _repository = repository;
    }

    public async Task<MerchantDto?> Handle(
        GetMerchantByIdQuery request,
        CancellationToken cancellationToken)
    {
        var merchant = await _repository.GetByIdAsync(request.Id);

        if (merchant == null)
            return null;

        return merchant.ToDto();
    }
}