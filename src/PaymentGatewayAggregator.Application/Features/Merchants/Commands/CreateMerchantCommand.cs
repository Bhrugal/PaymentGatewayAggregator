namespace PaymentGatewayAggregator.Application.Features.Merchants.Commands;

public class CreateMerchantCommand
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}