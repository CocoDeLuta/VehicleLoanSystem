using System;

namespace VehicleLoan.Model.Basic
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public virtual StateModel? State { get; set; }

        public CityModel(int id, string name, StateModel state)
        {
            CityId = id;
            Name = name;
            State = state;
        }

        public CityModel()
        {
            
        }

        public override string ToString()
        {
            return $"[CityId: {CityId}, Name: {Name}, State: {State}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is CityModel other)
            {
                return other.CityId == CityId;
            }
            return false;
        }

    }
}
