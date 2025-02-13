using System;

namespace VehicleLoan.Model.Basic
{
    public class ContractModel
    {

        

        public int ContractId { get; set; }
        public virtual ClientModel? Client { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public DateTime? ContractDate { get; set; }
        public double? ContractValue { get; set; }

        public ContractModel(int id, ClientModel client, VehicleModel vehicle, DateTime contDate, double plotValue)
        {
            ContractId = id;
            Client = client;
            Vehicle = vehicle;
            ContractDate = contDate;
            ContractValue = plotValue;
        }

        public ContractModel()
        {
            
        }

        public override string ToString()
        {
            return $"[ContractID: {ContractId}, Client: {Client}, Vehicle: {Vehicle}, ContractDate: {ContractDate}, ContractValue: {ContractValue}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ContractModel other)
            {
                return other.ContractId == ContractId;
            }
            return false;
        }

    }
}
