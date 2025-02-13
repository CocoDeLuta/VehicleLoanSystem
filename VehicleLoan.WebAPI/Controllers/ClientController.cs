using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;

    public ClientController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var clients = await context.Clients.ToListAsync();
        return Ok(clients);
    }

    [HttpGet("GetByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        var client = await context.Clients.FindAsync(id);
        return Ok(client);
    }

    [HttpPost("AddClient")]
    public async Task<IActionResult> AddClient(ClientModel client, int addressId)
    {
        var address = await context.Addresses.FindAsync(addressId);
        if (address == null)
        {
            return BadRequest("Address not found");
        }
        client.Address = address;
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();
        return Created("", client);
    }

    [HttpPut("UpdateClientByID")]
    public async Task<IActionResult> UpdateClientByID(int id)
    {
        var clientToUpdate = await context.Clients.FindAsync(id);
        if (clientToUpdate != null)
        {
            context.Clients.Update(clientToUpdate);
            await context.SaveChangesAsync();
            return Ok(clientToUpdate);
        }
        return NoContent();
    }

    [HttpDelete("DeleteClientByID")]
    public async Task<IActionResult> DeleteClientByID(int id)
    {
        var clientToDelete = await context.Clients.FindAsync(id);
        if (clientToDelete != null)
        {
            context.Clients.Remove(clientToDelete);
            await context.SaveChangesAsync();
            return Ok(clientToDelete);
        }
        return NoContent();
    }
}
