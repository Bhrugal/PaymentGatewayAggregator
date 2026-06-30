using PaymentGatewayAggregator.Domain.Common;
using PaymentGatewayAggregator.Domain.Enums;

//namespace PaymentGatewayAggregator.Domain.Entities;

//public class Payment : BaseEntity
//{
//    public Guid MerchantId { get; set; }

//    public string OrderId { get; set; } = string.Empty;

//    public decimal Amount { get; set; }

//    public string Currency { get; set; } = "USD";

//    public GatewayType Gateway { get; set; }

//    public PaymentStatus Status { get; set; }

//    public string? TransactionId { get; set; }
//}


namespace PaymentGatewayAggregator.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public Guid MerchantId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}