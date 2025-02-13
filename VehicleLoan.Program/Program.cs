using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleLoan.EFCore.DataContext;
using VehicleLoan.Model.Basic;


class Program
{
    static void Main(string[] args)
    {
        // Configure services
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Use the service provider to get the DbContext
        using (var context = serviceProvider.GetRequiredService<VehicleLoanEFCoreContext>())
        {
            // Your code to interact with the database goes here
            Console.WriteLine("Hello, World!");

            // Example: List all vehicles
            var addresses = context.Addresses.ToList();
            foreach (var address in addresses)
            {
                Console.WriteLine(address.ToString());
            }
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext with SQLite provider
        services.AddDbContext<VehicleLoanEFCoreContext>(options =>
            options.UseSqlite("Data Source=../VehicleLoan.EFCore/VehicleLoan.db"));
    }
}