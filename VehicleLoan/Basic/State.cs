using System;
using System.Collections.Concurrent;

namespace VehicleLoan.Model.Basic
{
    public class StateModel
    {
        public int StateId { get; set; } // Primary Key
        public string? Name { get; set; }
        public string? Initials { get; set; }
        public virtual CountryModel? Country { get; set; }
 

        public StateModel(int id, string name, string initials, CountryModel country)
        {
            StateId = id;
            Name = name;
            Initials = initials;
            Country = country;
        }
        public StateModel() // Empty constructor for Entity Framework
        {
            
        }
        


        public override string ToString()
        {
            return $"[StateId: {StateId}, Name: {Name}, Initials: {Initials}], Country: {Country}";
        }

        public override bool Equals(object obj)
        {
            if (obj is StateModel other)
            {
                return other.StateId == StateId;
            }
            return false;
        }
    }
}
