using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;

namespace PaymentGatewayAggregator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentRequest request)
    {
        var command = new CreatePaymentCommand
        {
            MerchantId = request.MerchantId,
            Amount = request.Amount,
            Currency = request.Currency
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}