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

namespace PaymentGatewayAggregator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MerchantsController : ControllerBase
{
    private readonly IMerchantRepository _merchantRepository;

    public MerchantsController(IMerchantRepository merchantRepository)
    {
        _merchantRepository = merchantRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var merchants = await _merchantRepository.GetAllAsync();

        return Ok(merchants.Select(x => x.ToDto()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var merchant = await _merchantRepository.GetByIdAsync(id);

        if (merchant == null)
            return NotFound();

        return Ok(merchant.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMerchantRequest request)
    {
        var merchant = request.ToEntity();

        await _merchantRepository.AddAsync(merchant);

        return Ok(merchant.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateMerchantRequest request)
    {
        var merchant = await _merchantRepository.GetByIdAsync(id);

        if (merchant == null)
            return NotFound();

        merchant.Name = request.Name;
        merchant.Email = request.Email;
        merchant.GatewayType = request.GatewayType;

        await _merchantRepository.UpdateAsync(merchant);

        return Ok(merchant.ToDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var merchant = await _merchantRepository.GetByIdAsync(id);

        if (merchant == null)
            return NotFound();

        await _merchantRepository.DeleteAsync(merchant);

        return Ok("Merchant deleted successfully");
    }
}