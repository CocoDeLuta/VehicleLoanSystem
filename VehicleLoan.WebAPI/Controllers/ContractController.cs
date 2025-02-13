using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;

    public ContractController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contracts = await context.Contracts.ToListAsync();
        return Ok(contracts);
    }

    [HttpGet("GetByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        var contract = await context.Contracts.FindAsync(id);
        return Ok(contract);
    }

    [HttpPost("AddContract")]
    public async Task<IActionResult> AddContract(ContractModel contract, int clientId, int vehicleId)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return BadRequest("Client not found");
        }
        var vehicle = await context.Vehicles.FindAsync(vehicleId);
        if (vehicle == null)
        {
            return BadRequest("Vehicle not found");
        }
        contract.Vehicle = vehicle;
        contract.Client = client;
        await context.Contracts.AddAsync(contract);
        await context.SaveChangesAsync();
        return Created("", contract);
    }

    [HttpPut("UpdateContractByID")]
    public async Task<IActionResult> UpdateContractByID(int id)
    {
        var contractToUpdate = await context.Contracts.FindAsync(id);
        if (contractToUpdate != null)
        {
            context.Contracts.Update(contractToUpdate);
            await context.SaveChangesAsync();
            return Ok(contractToUpdate);
        }
        return NoContent();
    }

    [HttpDelete("DeleteContractByID")]
    public async Task<IActionResult> DeleteContractByID(int id)
    {
        var contractToDelete = await context.Contracts.FindAsync(id);
        if (contractToDelete != null)
        {
            context.Contracts.Remove(contractToDelete);
            await context.SaveChangesAsync();
            return Ok(contractToDelete);
        }
        return NoContent();
    }
}
