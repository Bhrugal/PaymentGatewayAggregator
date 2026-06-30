using MediatR;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Commands;

public class DeleteMerchantCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteMerchantCommand(Guid id)
    {
        Id = id;
    }
}