using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Application.Interfaces;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class CreateMerchantHandler
    : IRequestHandler<CreateMerchantCommand, MerchantDto>
{
    private readonly IMerchantRepository _repository;

    public CreateMerchantHandler(IMerchantRepository repository)
    {
        _repository = repository;
    }

    public async Task<MerchantDto> Handle(
        CreateMerchantCommand request,
        CancellationToken cancellationToken)
    {
        var merchant = new Merchant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            GatewayType = request.GatewayType
        };

        await _repository.AddAsync(merchant);

        return new MerchantDto
        {
            Id = merchant.Id,
            Name = merchant.Name,
            Email = merchant.Email,
            GatewayType = merchant.GatewayType
        };
    }
}