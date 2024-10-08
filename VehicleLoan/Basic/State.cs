using System;

namespace VehicleLoan.Model.Basic
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public State(int id, string name, string initials)
        {
            StateId = id;
            Name = name;
            Initials = initials;
        }

        public override string ToString()
        {
            return $"[StateId: {StateId}, Name: {Name}, Initials: {Initials}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is State other)
            {
                return other.StateId == StateId;
            }
            return false;
        }
    }
}
