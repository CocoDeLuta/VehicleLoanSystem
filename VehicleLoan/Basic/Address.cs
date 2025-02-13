using System;

namespace VehicleLoan.Model.Basic
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public CityModel? City { get; set; }

        public AddressModel(int id, string street, string number, CityModel city)
        {
            AddressId = id;
            Street = street;
            Number = number;
            City = city;
        }

        public AddressModel()
        {
            
        }

        public override string ToString()
        {
            return $"[AddressID: {AddressId}, Street: {Street}, Number: {Number}, City: {City}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is AddressModel other)
            {
                return other.AddressId == AddressId;
            }
            return false;
        }
    }
}
