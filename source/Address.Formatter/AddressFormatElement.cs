using System;

namespace Address.Formatter
{
    public class AddressFormatElement
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        public string GetElementData(IAddress address)
        {
            switch (Name)
            {
                default:
                    throw new NotSupportedException(Name);

                case "PersonTitle":
                    return address.PersonTitle;
                case "PersonFirstName":
                    return address.PersonFirstName;
                case "PersonMiddleName":
                    return address.PersonMiddleName;
                case "PersonLastName":
                    return address.PersonLastName;
                case "CompanyName":
                    return address.CompanyName;
                case "Line1":
                    return address.Line1;
                case "Line2":
                    return address.Line2;
                case "Line3":
                    return address.Line3;
                case "City":
                    return address.City;
                case "State":
                    return address.State;
                case "CountryName":
                    return address.CountryName;
                case "PostalCode":
                    return address.PostalCode;
            }
        }
    }
}