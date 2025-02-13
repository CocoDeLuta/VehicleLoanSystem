using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;
[Route("api/[controller]")] // This attribute is used to define the route of the controller
[ApiController] // This attribute is required to use the ControllerBase class
public class CountryController : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;

    public CountryController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")] // This attribute is used to define the HTTP method
    public async Task<IActionResult> GetAll()
    {
        var countries = await context.Countries.ToListAsync();
        return Ok(countries);
    }
    
    [HttpGet("GetByID")] // This attribute is used to define the route of the method
    public async Task<IActionResult> GetByID(int id)
    {
        var country = await context.Countries.FindAsync(id);
        return Ok(country);
    }

    [HttpPost("AddCountry")] // This attribute is used to define the HTTP method
    public async Task<IActionResult> AddCountry(CountryModel country)
    {
        await context.Countries.AddAsync(country);
        await context.SaveChangesAsync();
        return Created("", country);
    }

    [HttpPut("UpdateCountryById")] // This attribute is used to define the HTTP method]
    public async Task<IActionResult> UpdateCountry(int id)
    {
        var country = await context.Countries.FindAsync(id);
        if (country == null)
        {
            return BadRequest("Country not found");
        }
        context.Countries.Update(country);
        await context.SaveChangesAsync();
        return Ok(country);
    }

    [HttpDelete("DeleteCountryById")] // This attribute is used to define the HTTP method
    public async Task<IActionResult> DeleteCountryByID(int id)
    {
        var countryToDelete = await context.Countries.FindAsync(id);
        if (countryToDelete != null)
        {
            context.Countries.Remove(countryToDelete);
            await context.SaveChangesAsync();
            return Ok(countryToDelete);
        }
        return NoContent();
    }
}
