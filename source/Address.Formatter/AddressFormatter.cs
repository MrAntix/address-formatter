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
            _formats = formats
                .ToDictionary(o => o.Identifier);
        }

        public string Format(IAddress address)
        {
            var format = GetFormatOrDefault(address.FormatIdentifier, _formats);

            var formattedElements
                = format.Elements
                        .Select(o => GetElementData(o, address));

            return string.Join(string.Empty, formattedElements).Trim();
        }

        public static string GetElementData(
            AddressFormatElement format, IAddress address)
        {
            if (format == null) throw new ArgumentNullException("format");
            if (address == null) throw new ArgumentNullException("address");

            var data = format.GetElementData(address);
            if (string.IsNullOrWhiteSpace(data)) return null;

            return string.Format("{0}{1}{2}{3}",
                                 format.NewLine ? Environment.NewLine : string.Empty,
                                 format.Prefix,
                                 data,
                                 format.Suffix
                );
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