// See https://aka.ms/new-console-template for more information
using VehicleLoan.Model.Basic;

Console.WriteLine("Hello, World!");

VehicleModel vehicle = new VehicleModel(1, "Toyota", 2020);
VehicleModel vehicle1 = new VehicleModel(1, "Toyota", 2020);

Console.WriteLine(vehicle.Equals(vehicle1)); // False