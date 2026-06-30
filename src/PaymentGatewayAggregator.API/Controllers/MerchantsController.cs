//using Microsoft.AspNetCore.Mvc;
//using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

//namespace PaymentGatewayAggregator.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class MerchantsController : ControllerBase
//{
//    private static readonly List<MerchantDto> Merchants = new();

//    [HttpGet]
//    public IActionResult GetAll()
//    {
//        return Ok(Merchants);
//    }

//    [HttpGet("{id}")]
//    public IActionResult GetById(Guid id)
//    {
//        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

//        if (merchant == null)
//            return NotFound();

//        return Ok(merchant);
//    }

//    [HttpPost]
//    public IActionResult Create(CreateMerchantRequest request)
//    {
//        var merchant = new MerchantDto
//        {
//            Id = Guid.NewGuid(),
//            Name = request.Name,
//            Email = request.Email,
//            GatewayType = request.GatewayType
//        };

//        Merchants.Add(merchant);

//        return Ok(merchant);
//    }

//    //[HttpPut("{id}")]
//    //public IActionResult Update(Guid id, UpdateMerchantRequest request)
//    //{
//    //    var merchant = Merchants.FirstOrDefault(x => x.Id == id);

//    //    if (merchant == null)
//    //        return NotFound();

//    //    merchant.Name = request.Name;
//    //    merchant.Email = request.Email;
//    //    merchant.GatewayType = request.GatewayType;

//    //    return Ok(merchant);
//    //}

//    [HttpPut("{id}")]
//    public IActionResult Update(Guid id, UpdateMerchantRequest request)
//    {
//        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

//        if (merchant == null)
//            return NotFound();

//        merchant.Name = request.Name;
//        merchant.Email = request.Email;
//        merchant.GatewayType = request.GatewayType;

//        return Ok(merchant);
//    }

//    [HttpDelete("{id}")]
//    public IActionResult Delete(Guid id)
//    {
//        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

//        if (merchant == null)
//            return NotFound();

//        Merchants.Remove(merchant);

//        return Ok("Merchant deleted successfully");
//    }
//}

using Microsoft.AspNetCore.Mvc;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Application.Mappings;
using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;
using PaymentGatewayAggregator.Application.Features.Merchants.Queries;

namespace PaymentGatewayAggregator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MerchantsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMerchantRepository _merchantRepository;

    public MerchantsController(
        IMediator mediator,
        IMerchantRepository merchantRepository)
    {
        _mediator = mediator;
        _merchantRepository = merchantRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllMerchantsQuery());

        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetMerchantByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateMerchantCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateMerchantCommand command)
    {
        command.Id = id;

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteMerchantCommand(id));

        if (!result)
            return NotFound();

        return Ok("Merchant deleted successfully");
    }
}