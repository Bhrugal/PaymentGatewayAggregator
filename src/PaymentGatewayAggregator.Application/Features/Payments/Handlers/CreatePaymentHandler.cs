using MediatR;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Features.Payments.Handlers;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentResponse>
{
    private readonly IPaymentRepository _paymentRepository;

    public CreatePaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<CreatePaymentResponse> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            MerchantId = request.MerchantId,
            Amount = request.Amount,
            Currency = request.Currency,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        await _paymentRepository.AddAsync(payment);

        return new CreatePaymentResponse
        {
            Id = payment.Id,
            Status = payment.Status
        };
    }
}