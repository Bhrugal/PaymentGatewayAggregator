namespace PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

public class MerchantDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}