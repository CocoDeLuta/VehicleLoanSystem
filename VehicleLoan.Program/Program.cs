// See https://aka.ms/new-console-template for more information
using VehicleLoan.Model.Basic;

Console.WriteLine("Hello, World!");

VehicleModel vehicle = new VehicleModel(1, "Toyota", 2020);
VehicleModel vehicle1 = new VehicleModel(1, "Toyota", 2020);

Console.WriteLine(vehicle.Equals(vehicle1)); // False
Console.WriteLine(vehicle); 
Console.WriteLine("====================================");

ClienteModel cliente = new ClienteModel(1, "João", "123.456.789-00", "1234-5678", "Rua 1");
ClienteModel cliente1 = new ClienteModel(1, "João", "123.456.789-00", "1234-5678", "Rua 1");

Console.WriteLine(cliente.Equals(cliente1)); // True
Console.WriteLine(cliente); 
Console.WriteLine("====================================");

ContratoModel contrato = new ContratoModel(1, cliente, vehicle, DateTime.Now, 1000);
ContratoModel contrato1 = new ContratoModel(1, cliente, vehicle, DateTime.Now, 1000);

Console.WriteLine(contrato.Equals(contrato1)); // True
Console.WriteLine(contrato);
Console.WriteLine("====================================");