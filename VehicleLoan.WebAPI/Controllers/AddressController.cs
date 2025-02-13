using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController  : ControllerBase
{
    private readonly VehicleLoanEFCoreContext context;

    public AddressController(VehicleLoanEFCoreContext context)
    {
        this.context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var addresses = await context.Addresses.ToListAsync();
        return Ok(addresses);
    }

    [HttpGet("GetByID")]
    public async Task<IActionResult> GetByID(int id)
    {
        var address = await context.Addresses.FindAsync(id);
        return Ok(address);
    }

    [HttpPost("AddAddress")]
    public async Task<IActionResult> AddAddress(AddressModel address, int cityId)
    {
        var city = await context.Cities.FindAsync(cityId);
        if (city == null)
        {
            return BadRequest("City not found");
        }
        address.City = city;
        await context.Addresses.AddAsync(address);
        await context.SaveChangesAsync();
        return Created("", address);
    }

    [HttpPut("UpdateAddressByID")]
    public async Task<IActionResult> UpdateAddressByID(int id)
    {
        var addressToUpdate = await context.Addresses.FindAsync(id);
        if (addressToUpdate != null)
        {
            context.Addresses.Update(addressToUpdate);
            await context.SaveChangesAsync();
            return Ok(addressToUpdate);
        }
        return NoContent();
    }

    [HttpDelete("DeleteAddressByID")]
    public async Task<IActionResult> DeleteAddressByID(int id)
    {
        var addressToDelete = await context.Addresses.FindAsync(id);
        if (addressToDelete != null)
        {
            context.Addresses.Remove(addressToDelete);
            await context.SaveChangesAsync();
            return Ok(addressToDelete);
        }
        return NoContent();
    }
}
