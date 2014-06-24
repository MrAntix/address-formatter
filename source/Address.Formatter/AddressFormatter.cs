using System;
using System.Collections.Generic;
using System.Linq;

namespace Address.Formatter
{
    public class AddressFormatter
    {
        readonly IDictionary<string, AddressFormat> _formats;

        public AddressFormatter(IEnumerable<AddressFormat> formats)
        {
            _formats = (from format in formats
                        from identifier in format.Identifiers
                        select new
                            {
                                key = identifier,
                                value = format
                            })
                .ToDictionary(o => o.key, o => o.value);
        }

        public string Format(IAddress address)
        {
            var format = GetFormatOrDefault(address.FormatIdentifier, _formats);

            var formattedElements
                = format.Lines
                        .Select(line => GetLineData(line, address));

            return string.Join(string.Empty, formattedElements).Trim();
        }

        public static string GetLineData(
            AddressFormatLine format, IAddress address)
        {
            if (format == null) throw new ArgumentNullException("format");
            if (address == null) throw new ArgumentNullException("address");

            var data = string.Join(
                format.ElementSeparator,
                format.Elements
                      .Select(element => GetElementData(element, address))
                      .Where(d => !string.IsNullOrWhiteSpace(d)));

            if (string.IsNullOrWhiteSpace(data)) return null;

            if (format.Trim) data = data.Trim();

            return string.Format("{0}{1}{2}{3}",
                                 format.Prefix,
                                 data.Trim(),
                                 format.Suffix,
                                 Environment.NewLine);
        }

        public static string GetElementData(
            AddressFormatElement format, IAddress address)
        {
            if (format == null) throw new ArgumentNullException("format");
            if (address == null) throw new ArgumentNullException("address");

            var data = GetElementData(format.Name, address);
            if (string.IsNullOrWhiteSpace(data)) return null;

            if (format.ToUppercase) data = data.ToUpper();
            if (format.Trim) data = data.Trim();

            return string.Format("{0}{1}{2}",
                                 format.Prefix,
                                 data,
                                 format.Suffix
                );
        }

        static string GetElementData(
            string name, IAddress address)
        {
            switch (name)
            {
                default:
                    throw new NotSupportedException(name);

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
                case "CountryCode":
                    return address.CountryCode;
                case "CountryName":
                    return address.CountryName;
                case "PostalCode":
                    return address.PostalCode;
            }
        }

        public static AddressFormat GetFormatOrDefault(
            string identifier,
            IDictionary<string, AddressFormat> formats)
        {
            if (identifier == null) throw new ArgumentNullException("identifier");
            if (formats == null) throw new ArgumentNullException("formats");

            if (formats.ContainsKey(identifier))
                return formats[identifier];

            if (formats.ContainsKey(string.Empty))
                return formats[string.Empty];

            throw new AddressFormatNotFoundException(identifier);
        }
    }
}