using PaymentGatewayAggregator.Application.Features.Merchants.Commands;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class DeleteMerchantHandler
{
    public bool Handle(DeleteMerchantCommand command)
    {
        // Temporary implementation.
        // When we integrate SQL Server, this will delete the merchant from the database.
        return true;
    }
}