using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;
using ManagementSystem.Application.CQRS.Customers.Queries.Requests;
using ManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        return Ok(await _sender.Send(request));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerRequest request)
    {
        return Ok(await _sender.Send(request));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var request = new DeleteCustomerRequest { Id = id };
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] UpdateCustomerRequest request)
    {
        return Ok(await _sender.Send(request));
    }
}
