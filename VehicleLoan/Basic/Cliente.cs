using System;

namespace VehicleLoan.Model.Basic
{
    public class ClienteModel
    {

        public int? clienteID { get; set; }
        public string? nome { get; set; }
        public string? cpf { get; set; }
        public string? telefone { get; set; }
        public string? endereco { get; set; }

        public ClienteModel(int id, string nome, string cpf, string telefone, string endereco)
        {
            clienteID = id;
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        

        public override string ToString()
        {
            return $"[ClienteID: {clienteID}, Nome: {nome}, CPF: {cpf}, Telefone: {telefone}, Endereco: {endereco}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ClienteModel other)
            {
                return other.clienteID == clienteID;
            }
            return false;
        }

    }
}
