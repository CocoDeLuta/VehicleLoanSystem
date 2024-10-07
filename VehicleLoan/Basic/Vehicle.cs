using System;

namespace VehicleLoan.Model.Basic
{
    public class VehicleModel
    {
        public int? vehicleId { get; set; }
        public string? modelName { get; set; }
        public int? year { get; set; }


        public VehicleModel(int id, string model, int year)
        {
            vehicleId = id;
            modelName = model;
            year = year;
        }

        public override string ToString()
        {
            return $"[VehicleId: {vehicleId}, ModelName: {modelName}, Year: {year}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is VehicleModel other)
            {
                return other.vehicleId == vehicleId;
            }
            return false;
        }

    }
}
