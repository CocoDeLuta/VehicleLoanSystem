using System;

namespace VehicleLoan.Model.Basic
{
    public class ContractModel
    {

        

        public int? ContractID { get; set; }
        public ClientModel? Client { get; set; }
        public VehicleModel? Vehicle { get; set; }
        public DateTime? ContractDate { get; set; }
        public double? ContractValue { get; set; }

        public ContractModel(int id, ClientModel cliente, VehicleModel vehicle, DateTime dataContrato, double valorParcela)
        {
            ContractID = id;
            Client = cliente;
            Vehicle = vehicle;
            ContractDate = dataContrato;
            ContractValue = valorParcela;
        }

        public override string ToString()
        {
            return $"[ContractID: {ContractID}, Client: {Client}, Vehicle: {Vehicle}, ContractDate: {ContractDate}, ContractValue: {ContractValue}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ContractModel other)
            {
                return other.ContractID == ContractID;
            }
            return false;
        }

    }
}
