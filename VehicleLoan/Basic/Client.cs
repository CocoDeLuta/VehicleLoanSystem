using System;

namespace VehicleLoan.Model.Basic
{
    public class ClientModel
    {

        public int ClientID { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public Address? Address { get; set; }

        public ClientModel(int id, string nome, string cpf, string telefone, Address endereco)
        {
            ClientID = id;
            Name = nome;
            Cpf = cpf;
            Telefone = telefone;
            Address = endereco;
        }
        

        public override string ToString()
        {
            return $"[ClientID: {ClientID}, Name: {Name}, Cpf: {Cpf}, Telefone: {Telefone}, Address: {Address}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ClientModel other)
            {
                return other.ClientID == ClientID;
            }
            return false;
        }

    }
}
