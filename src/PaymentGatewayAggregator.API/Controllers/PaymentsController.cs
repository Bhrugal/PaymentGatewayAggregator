using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;
using PaymentGatewayAggregator.Application.Features.Payments.DTOs;
using PaymentGatewayAggregator.Application.Features.Payments.Queries;

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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPaymentByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdatePaymentRequest request)
    {
        var command = new UpdatePaymentCommand
        {
            Id = id,
            Amount = request.Amount,
            Currency = request.Currency,
            Status = request.Status
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
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


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeletePaymentCommand(id));

        if (!result)
            return NotFound();

        return Ok("Payment deleted successfully.");
    }
}