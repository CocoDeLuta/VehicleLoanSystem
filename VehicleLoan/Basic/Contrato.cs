using System;

namespace VehicleLoan.Model.Basic
{
    public class ContratoModel
    {

        public int? contradoID { get; set; }    
        public ClienteModel? cliente { get; set; }
        public VehicleModel? vehicle { get; set; }
        public DateTime? dataContrato { get; set; }
        public double? valorParcela { get; set; }

        public ContratoModel(int id, ClienteModel cliente, VehicleModel vehicle, DateTime dataContrato, double valorParcela)
        {
            contradoID = id;
            this.cliente = cliente;
            this.vehicle = vehicle;
            this.dataContrato = dataContrato;
            this.valorParcela = valorParcela;
        }

        public override string ToString()
        {
            return $"[ContratoID: {contradoID}, Cliente: {cliente}, Vehicle: {vehicle}, DataContrato: {dataContrato}, ValorParcela: {valorParcela}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is ContratoModel other)
            {
                return other.contradoID == contradoID;
            }
            return false;
        }

    }
}
