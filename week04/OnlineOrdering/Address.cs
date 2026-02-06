using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUsa()
    {
        return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase) ||
               _country.Trim().Equals("United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
