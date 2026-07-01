using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;

namespace PaymentGatewayAggregator.Application.Features.Payments.Handlers;

public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, PaymentDto?>
{
    private readonly IPaymentRepository _paymentRepository;

    public UpdatePaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto?> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment == null)
            return null;

        payment.Amount = request.Amount;
        payment.Currency = request.Currency;
        payment.Status = request.Status;

        await _paymentRepository.UpdateAsync(payment);

        return new PaymentDto
        {
            Id = payment.Id,
            MerchantId = payment.MerchantId,
            Amount = payment.Amount,
            Currency = payment.Currency,
            Status = payment.Status,
            CreatedAt = payment.CreatedAt
        };
    }
}