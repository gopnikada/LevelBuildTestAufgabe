using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Levelbuild.CodingChallenge.Api.Models;
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
    private readonly IMapper mapper;

    public CustomerController(ICustomerHandler customerHandler, IMapper mapper)
    {
        this.customerHandler = customerHandler ?? throw new ArgumentNullException(nameof(customerHandler));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<CustomerModel>>> GetCustomers()
    {

        IEnumerable<CustomerModel> customersFromHandler = await this.customerHandler.GetAllAsync().ConfigureAwait(false);

        IEnumerable<CustomerDataModel> customers = this.mapper.Map<IEnumerable<CustomerDataModel>>(customersFromHandler);

        IQueryable<CustomerDataModel> asQueryable =
            new EnumerableQuery<CustomerDataModel>(customers);

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