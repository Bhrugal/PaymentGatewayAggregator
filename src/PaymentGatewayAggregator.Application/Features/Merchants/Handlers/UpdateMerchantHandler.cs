using PaymentGatewayAggregator.Application.Features.Merchants.Commands;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class UpdateMerchantHandler
{
    public MerchantDto Handle(UpdateMerchantCommand command)
    {
        return new MerchantDto
        {
            Id = command.Id,
            Name = command.Name,
            Email = command.Email,
            GatewayType = command.GatewayType
        };
    }
}