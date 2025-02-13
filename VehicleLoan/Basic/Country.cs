using System;

namespace VehicleLoan.Model.Basic;

public class CountryModel
{
    public int CountryId { get; set; } // Primary Key
    public string? Name { get; set; }
    public string? Initials { get; set; }


    public CountryModel(int id, string name, string initials)
    {
        CountryId = id;
        Name = name;
        Initials = initials;
    }
    public CountryModel() // Empty constructor for Entity Framework
    {
        
    }

    public override string ToString()
    {
        return $"[CountryId: {CountryId}, Name: {Name}, Initials: {Initials}]";
    }

    public override bool Equals(object obj)
    {
        if (obj is CountryModel other)
        {
            return other.CountryId == CountryId;
        }
        return false;
    }

}
