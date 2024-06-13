using Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Levelbuild.CodingChallenge.Api.Controllers;

[ApiController]
[Route("api/Customer/{customerId}/[controller]")]
[Produces("application/json")]
public class UserController : Controller
{
    private readonly ICustomerHandler userHandler;

    public UserController(ICustomerHandler userHandler)
    {
        this.userHandler = userHandler;
    }
    [HttpGet]
    public IActionResult List()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPatch]
    [Route("{id}")]
    public IActionResult Update()
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}