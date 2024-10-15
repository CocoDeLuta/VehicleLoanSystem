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

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await context.Vehicles.ToListAsync();
        return Ok(vehicles);
    }

    [HttpGet("GetByID")]
    public async Task<IActionResult> GetVehicleByID(int id)
    {
        // find async is used to search by primary key
        var vehicle = await context.Vehicles.FindAsync(id);
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicle(VehicleModel vehicle)
    {
        await context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
        return Created("", vehicle);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateVehicle(VehicleModel vehicle)
    {
        context.Vehicles.Update(vehicle);
        await context.SaveChangesAsync();
        return Ok(vehicle);
    }

    [HttpDelete]
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