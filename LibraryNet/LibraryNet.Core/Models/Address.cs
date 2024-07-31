namespace LibraryNet.Core.Models
{
    public class Address
    {
        public Address(string streetName, string number, string neighborhood, string postalCode, string city, string state)
        {
            StreetName = streetName;
            Number = number;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
            City = city;
            State = state;
        }

        public string StreetName { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
