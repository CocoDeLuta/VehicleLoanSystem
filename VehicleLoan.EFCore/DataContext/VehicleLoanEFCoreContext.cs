using System;
using Microsoft.EntityFrameworkCore;
using VehicleLoan.Model.Basic;
using Microsoft.EntityFrameworkCore.Proxies;

namespace VehicleLoan.EFCore.DataContext;

public class VehicleLoanEFCoreContext : DbContext
{
    public VehicleLoanEFCoreContext(DbContextOptions<VehicleLoanEFCoreContext> options) : base(options)
    {
        
    }

    public VehicleLoanEFCoreContext()
    {
        
    }

    public DbSet<VehicleModel> Vehicles { get; set; } // This is the table that will be created in the database
    public DbSet<ClientModel> Clients { get; set; } // This is the table that will be created in the database
    public DbSet<AddressModel> Addresses { get; set; } // This is the table that will be created in the database
    public DbSet<CityModel> Cities { get; set; } // This is the table that will be created in the database
    public DbSet<StateModel> States { get; set; } // This is the table that will be created in the database
    public DbSet<CountryModel> Countries { get; set; } // This is the table that will be created in the database
    public DbSet<ContractModel> Contracts { get; set; } // This is the table that will be created in the database

    // Descomentar o metodo para fazer a migração
    // Deixar comentado para usar o swagger se nao da problema com o banco de dados
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source=./VehicleLoan.db");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure the primary key for the VehicleModel
        modelBuilder.Entity<VehicleModel>(eb =>
            {
                // Configure the primary key for the VehicleModel
                eb.HasKey(pk => pk.VehicleId);
                
            });
        
        // Configure the primary key for the ClientModel
        modelBuilder.Entity<ClientModel>(eb =>
            {
                // Configure the primary key for the ClientModel
                eb.HasKey(pk => pk.ClientId);
                
            });

        // Configure the primary key for the AddressModel
        modelBuilder.Entity<AddressModel>(eb =>
            {
                // Configure the primary key for the AddressModel
                eb.HasKey(pk => pk.AddressId);
                
            });

        // Configure the primary key for the CityModel
        modelBuilder.Entity<CityModel>(eb =>
            {
                // Configure the primary key for the CityModel
                eb.HasKey(pk => pk.CityId);
                
            });

        // Configure the primary key for the StateModel
        modelBuilder.Entity<StateModel>(eb =>
            {
                // Configure the primary key for the StateModel
                eb.HasKey(pk => pk.StateId);
                
            });

        // Configure the primary key for the CountryModel
        modelBuilder.Entity<CountryModel>(eb =>
            {
                // Configure the primary key for the CountryModel
                eb.HasKey(pk => pk.CountryId);
                
            });

        // Configure the primary key for the ContractModel
        modelBuilder.Entity<ContractModel>(eb =>
            {
                // Configure the primary key for the ContractModel
                eb.HasKey(pk => pk.ContractId);
                
            });
    }
}
