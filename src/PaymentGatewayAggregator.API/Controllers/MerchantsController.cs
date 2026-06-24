using Microsoft.AspNetCore.Mvc;

namespace PaymentGatewayAggregator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MerchantsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new[]
        {
            new
            {
                Id = Guid.NewGuid(),
                Name = "Amazon",
                Email = "amazon@test.com"
            },
            new
            {
                Id = Guid.NewGuid(),
                Name = "Netflix",
                Email = "netflix@test.com"
            }
        });
    }
}