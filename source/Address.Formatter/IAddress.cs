namespace Address.Formatter
{
    public interface IAddress
    {
        string PersonTitle { get; }
        string PersonFirstName { get; }
        string PersonMiddleName { get; }
        string PersonLastName { get; }

        string CompanyName { get; }

        string Line1 { get; }
        string Line2 { get; }
        string Line3 { get; }
        string City { get; }
        string State { get; }
        string CountryCode { get; }
        string CountryName { get; }
        string PostalCode { get; }

        string FormatIdentifier { get; }
    }
}