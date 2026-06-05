using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Service;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController(IPCService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllPC(cancellationToken));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetByIdAsync(id, cancellationToken));    
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePCRequest req, CancellationToken cancellationToken)
    {
        var pc = await service.AddAsync(req, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pc.Id }, pc);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePCRequest req, CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdateAsync(id, req, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
    }
}