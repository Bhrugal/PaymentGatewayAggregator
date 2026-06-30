using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Commands;

public class UpdateMerchantCommand : IRequest<MerchantDto?>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string GatewayType { get; set; } = string.Empty;
}