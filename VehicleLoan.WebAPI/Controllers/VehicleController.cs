using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controller;
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;
    public VehicleController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await context.Vehicles.ToListAsync();
        return Ok(vehicles);
    }

    [HttpGet("GetByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        // find async is used to search by primary key
        var vehicle = await context.Vehicles.FindAsync(id);
        return Ok(vehicle);
    }

    [HttpPost("AddVehicle")]
    public async Task<IActionResult> AddVehicle(VehicleModel vehicle)
    {
        await context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
        return Created("", vehicle);
    }

    [HttpPut("UpdateVehicleByID")]
    public async Task<IActionResult> UpdateVehicle(int id)
    {
        var vehicle = await context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return BadRequest("Vehicle not found");
        }
        context.Vehicles.Update(vehicle);
        await context.SaveChangesAsync();
        return Ok(vehicle);
    }

    [HttpDelete("DeleteVehicleByID")]
    public async Task<IActionResult> DeleteVehicleByID(int id)
    {
        var vehicleToDelete = await context.Vehicles.FindAsync(id);
        if (vehicleToDelete != null)
        {
            context.Vehicles.Remove(vehicleToDelete);
            await context.SaveChangesAsync();
            return Ok(vehicleToDelete);
        }
        return NoContent();
    }


}