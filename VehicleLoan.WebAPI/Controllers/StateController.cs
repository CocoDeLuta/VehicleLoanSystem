using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{

    private readonly VehicleLoanEFCoreContext context;
    public StateController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var states = await context.States.ToListAsync();
        foreach (var state in states)
        {
            // first, get the countryId from the database
            var countryId = state.Country.CountryId;
            // then, get the country from the database
            var country = await context.Countries.FindAsync(countryId);
            // finally, set the country of the state
            state.Country = country;
            
        }
        return Ok(states);
    }

    [HttpGet("GetStateByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        // find async is used to search by primary key
        var state = await context.States.FindAsync(id);
        return Ok(state);
    }

    [HttpPost("AddState")]
    public async Task<IActionResult> AddVehicle(StateModel state, int countryId)
    {
        var country = await context.Countries.FindAsync(countryId);
        if (country == null)
        {
            return BadRequest("Country not found");
        }
        state.Country = country;
        if(state.Country == null)
        {
            return BadRequest("Country not found");
        }
        await context.States.AddAsync(state);
        await context.SaveChangesAsync();
        return Created("", state);
    }

    [HttpPut("UpdateStateByID")]
    public async Task<IActionResult> UpdateStateByID(int id)
    {
        var stateToUpdate = await context.States.FindAsync(id);
        if(stateToUpdate != null)
        {
            context.States.Update(stateToUpdate);
            await context.SaveChangesAsync();
            return Ok(stateToUpdate);
        }
        return NoContent();
    }

    [HttpDelete("DeleteStateByID")]
    public async Task<IActionResult> DeleteStateByID(int id)
    {
        var stateToDelete = await context.States.FindAsync(id);
        if (stateToDelete != null)
        {
            context.States.Remove(stateToDelete);
            await context.SaveChangesAsync();
            return Ok(stateToDelete);
        }
        return NoContent();
    }

}
