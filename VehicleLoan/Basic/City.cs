using System;

namespace VehicleLoan.Model.Basic
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public State State { get; set; }

        public City(int id, string name, State state)
        {
            CityId = id;
            Name = name;
            State = state;
        }

        public override string ToString()
        {
            return $"[CityId: {CityId}, Name: {Name}, State: {State}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is City other)
            {
                return other.CityId == CityId;
            }
            return false;
        }

    }
}
