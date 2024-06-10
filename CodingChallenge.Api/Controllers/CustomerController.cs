using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Levelbuild.CodingChallenge.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Levelbuild.CodingChallenge.Api.Controllers;

[ApiController]
[Route("odata/[controller]")]
[Produces("application/json")]
public class CustomerController : Controller
{
    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<Customer>> GetCustomers()
    {
        IQueryable<Customer> asQueryable =
            new EnumerableQuery<Customer>(new List<Customer>()
            {
                new Customer() { Id = Guid.NewGuid(), Name = "name1", WebSite = "ws1"},
                new Customer() { Id = Guid.NewGuid(), Name = "name2", WebSite = "ws2"},
                new Customer() { Id = Guid.NewGuid(), Name = "name3", WebSite = "ws3"},
                new Customer() { Id = Guid.NewGuid(), Name = "name4", WebSite = "ws4"},
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