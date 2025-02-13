using System;

namespace VehicleLoan.Model.Basic
{
    public class ClientModel
    {

        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
        public AddressModel? Address { get; set; }

        public ClientModel(int id, string name, string cpf, string phone, AddressModel address)
        {
            ClientId = id;
            Name = name;
            Cpf = cpf;
            Phone = phone;
            Address = address;
        }

        public ClientModel()
        {
            
        }
        

        public override string ToString()
        {
            return $"[ClientID: {ClientId}, Name: {Name}, Cpf: {Cpf}, Telefone: {Phone}, Address: {Address}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ClientModel other)
            {
                return other.ClientId == ClientId;
            }
            return false;
        }

    }
}
