using Microsoft.AspNetCore.Mvc;
using PaymentGatewayAggregator.Application.Features.Merchants.DTOs;

namespace PaymentGatewayAggregator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MerchantsController : ControllerBase
{
    private static readonly List<MerchantDto> Merchants = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Merchants);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

        if (merchant == null)
            return NotFound();

        return Ok(merchant);
    }

    [HttpPost]
    public IActionResult Create(CreateMerchantRequest request)
    {
        var merchant = new MerchantDto
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            GatewayType = request.GatewayType
        };

        Merchants.Add(merchant);

        return Ok(merchant);
    }

    //[HttpPut("{id}")]
    //public IActionResult Update(Guid id, UpdateMerchantRequest request)
    //{
    //    var merchant = Merchants.FirstOrDefault(x => x.Id == id);

    //    if (merchant == null)
    //        return NotFound();

    //    merchant.Name = request.Name;
    //    merchant.Email = request.Email;
    //    merchant.GatewayType = request.GatewayType;

    //    return Ok(merchant);
    //}

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateMerchantRequest request)
    {
        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

        if (merchant == null)
            return NotFound();

        merchant.Name = request.Name;
        merchant.Email = request.Email;
        merchant.GatewayType = request.GatewayType;

        return Ok(merchant);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var merchant = Merchants.FirstOrDefault(x => x.Id == id);

        if (merchant == null)
            return NotFound();

        Merchants.Remove(merchant);

        return Ok("Merchant deleted successfully");
    }
}