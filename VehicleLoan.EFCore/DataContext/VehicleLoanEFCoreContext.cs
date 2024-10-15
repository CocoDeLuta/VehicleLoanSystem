using System;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.Model.Basic;

namespace VehicleLoan.EFCore.DataContext;

public class VehicleLoanEFCoreContext : DbContext
{
    public VehicleLoanEFCoreContext(DbContextOptions<VehicleLoanEFCoreContext> options) : base(options)
    //public VehicleLoanEFCoreContext()
    {
        
    }

    public DbSet<VehicleModel> Vehicles { get; set; }

    // This method is used to configure the database connection
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source=./VehicleLoan.db");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the primary key for the VehicleModel
        modelBuilder.Entity<VehicleModel>(eb =>
            {
                // Configure the primary key for the VehicleModel
                eb.HasKey(pk => pk.VehicleId);
                
            });
    }
}
