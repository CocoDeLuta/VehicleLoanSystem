using System;

namespace VehicleLoan.Model.Basic
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public City City { get; set; }

        public Address(int id, string street, string number, City city)
        {
            AddressID = id;
            Street = street;
            Number = number;
            City = city;
        }

        public override string ToString()
        {
            return $"[AddressID: {AddressID}, Street: {Street}, Number: {Number}, City: {City}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Address other)
            {
                return other.AddressID == AddressID;
            }
            return false;
        }
    }
}
