using System;

namespace VehicleLoan.Model.Basic
{
    public class VehicleModel
    {
        public int? VehicleId { get; set; }
        public string? ModelName { get; set; }
        public int? Year { get; set; }


        public VehicleModel(int id, string model, int year)
        {
            VehicleId = id;
            ModelName = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"[VehicleId: {VehicleId}, ModelName: {ModelName}, Year: {Year}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is VehicleModel other)
            {
                return other.VehicleId == VehicleId;
            }
            return false;
        }

    }
}
