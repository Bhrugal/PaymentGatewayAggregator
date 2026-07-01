using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;

namespace PaymentGatewayAggregator.Application.Features.Payments.Handlers;

public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, bool>
{
    private readonly IPaymentRepository _paymentRepository;

    public DeletePaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment == null)
            return false;

        await _paymentRepository.DeleteAsync(payment);

        return true;
    }
}