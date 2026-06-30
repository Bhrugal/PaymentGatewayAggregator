using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Application.Mappings;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class UpdateMerchantHandler
    : IRequestHandler<UpdateMerchantCommand, MerchantDto?>
{
    private readonly IMerchantRepository _repository;

    public UpdateMerchantHandler(IMerchantRepository repository)
    {
        _repository = repository;
    }

    public async Task<MerchantDto?> Handle(
        UpdateMerchantCommand request,
        CancellationToken cancellationToken)
    {
        var merchant = await _repository.GetByIdAsync(request.Id);

        if (merchant == null)
            return null;

        merchant.Name = request.Name;
        merchant.Email = request.Email;
        merchant.GatewayType = request.GatewayType;

        await _repository.UpdateAsync(merchant);

        return merchant.ToDto();
    }
}