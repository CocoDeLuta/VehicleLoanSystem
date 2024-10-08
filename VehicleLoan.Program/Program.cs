using VehicleLoan.Model.Basic;

Console.Clear();
Console.WriteLine("Hello, World!");

VehicleModel vehicle = new VehicleModel(1, "Toyota", 2020);
VehicleModel vehicle1 = new VehicleModel(1, "Toyota", 2020);

Console.WriteLine(vehicle.Equals(vehicle1)); // False
Console.WriteLine(vehicle); 
Console.WriteLine("====================================");

State state = new State(1, "São Paulo", "SP");
City city = new City(1, "São Paulo", state);
Address address = new Address(1, "Rua 1", "123", city);

Console.WriteLine(address);
Console.WriteLine("====================================");

ClientModel client = new ClientModel(1, "João", "123456789", "1234", address);
ClientModel client1 = new ClientModel(1, "João", "123456789", "1234", address);

Console.WriteLine(client.Equals(client1)); // True
Console.WriteLine(client);
Console.WriteLine("====================================");

ContractModel contract = new ContractModel(1, client, vehicle, DateTime.Now, 1000);
ContractModel contract1 = new ContractModel(1, client, vehicle, DateTime.Now, 1000);

Console.WriteLine(contract.Equals(contract1)); // True
Console.WriteLine(contract);
Console.WriteLine("====================================");
