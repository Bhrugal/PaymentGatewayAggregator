using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;
using PaymentGatewayAggregator.Application.Features.Payments.Queries;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;

namespace PaymentGatewayAggregator.Application.Features.Payments.Handlers;

public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto?>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentByIdHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto?> Handle(
        GetPaymentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment == null)
            return null;

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