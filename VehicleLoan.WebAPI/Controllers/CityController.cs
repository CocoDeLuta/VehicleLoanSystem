using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;

    public CityController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var cities = await context.Cities.ToListAsync();
        return Ok(cities);
    }

    [HttpGet("GetCityByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        var city = await context.Cities.FindAsync(id);
        return Ok(city);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(CityModel city, int stateId)
    {
        var state = await context.States.FindAsync(stateId);
        if (state == null)
        {
            return BadRequest("State not found");
        }
        city.State = state;
        await context.Cities.AddAsync(city);
        await context.SaveChangesAsync();
        return Created("", city);
    }

    [HttpPut("UpdateCityByID")]
    public async Task<IActionResult> UpdateCityByID(int id)
    {
        var cityToUpdate = await context.Cities.FindAsync(id);
        if (cityToUpdate != null)
        {
            context.Cities.Update(cityToUpdate);
            await context.SaveChangesAsync();
            return Ok(cityToUpdate);
        }
        return NoContent();
    }

    [HttpDelete("DeleteCityByID")]
    public async Task<IActionResult> DeleteCityByID(int id)
    {
        var cityToDelete = await context.Cities.FindAsync(id);
        if (cityToDelete != null)
        {
            context.Cities.Remove(cityToDelete);
            await context.SaveChangesAsync();
            return Ok(cityToDelete);
        }
        return NoContent();
    }
    
}
