using PaymentGatewayAggregator.Domain.Common;

namespace PaymentGatewayAggregator.Domain.Entities;

public class Merchant : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ApiKey { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}