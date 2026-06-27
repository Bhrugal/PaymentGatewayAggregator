using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Mappings;

public static class MerchantMapping
{
    public static MerchantDto ToDto(this Merchant merchant)
    {
        return new MerchantDto
        {
            Id = merchant.Id,
            Name = merchant.Name,
            Email = merchant.Email,
            GatewayType = merchant.GatewayType
        };
    }

    public static Merchant ToEntity(this CreateMerchantRequest request)
    {
        return new Merchant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            GatewayType = request.GatewayType.ToString(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };
    }
}