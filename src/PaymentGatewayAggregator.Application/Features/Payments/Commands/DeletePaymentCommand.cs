using MediatR;

namespace PaymentGatewayAggregator.Application.Features.Payments.Commands;

public class DeletePaymentCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeletePaymentCommand(Guid id)
    {
        Id = id;
    }
}