//namespace PaymentGatewayAggregator.Application.Features.Merchants.Commands;

//public class CreateMerchantCommand
//{
//    public string Name { get; set; } = string.Empty;

//    public string Email { get; set; } = string.Empty;
//}


using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Commands;

public class CreateMerchantCommand : IRequest<MerchantDto>
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string GatewayType { get; set; } = string.Empty;
}