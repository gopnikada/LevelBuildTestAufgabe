using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Levelbuild.CodingChallenge.Api.Controllers;

[ApiController]
[Route("odata/[controller]")]
[Produces("application/json")]
public class CustomerController : Controller
{
    private readonly ICustomerHandler customerHandler;

    public CustomerController(ICustomerHandler customerHandler)
    {
        this.customerHandler = customerHandler;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<CustomerModel>>> GetCustomers()
    {

        var customers = await this.customerHandler.GetAllAsync().ConfigureAwait(false);

        IQueryable<CustomerModel> asQueryable =
            new EnumerableQuery<CustomerModel>(new List<CustomerModel>()
            {
                new CustomerModel() { Id = Guid.NewGuid(), Name = "name1", WebSite = "ws1"},
                new CustomerModel() { Id = Guid.NewGuid(), Name = "name2", WebSite = "ws2"},
                new CustomerModel() { Id = Guid.NewGuid(), Name = "name3", WebSite = "ws3"},
                new CustomerModel() { Id = Guid.NewGuid(), Name = "name4", WebSite = "ws4"},
            });

        return Ok(asQueryable);
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