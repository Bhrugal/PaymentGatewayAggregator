using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;
using PaymentGatewayAggregator.Application.Features.Payments.Queries;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;

namespace PaymentGatewayAggregator.Application.Features.Payments.Handlers;

public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDto>>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetAllPaymentsHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<List<PaymentDto>> Handle(
        GetAllPaymentsQuery request,
        CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetAllAsync();

        return payments.Select(payment => new PaymentDto
        {
            Id = payment.Id,
            MerchantId = payment.MerchantId,
            Amount = payment.Amount,
            Currency = payment.Currency,
            Status = payment.Status,
            CreatedAt = payment.CreatedAt
        }).ToList();
    }
}