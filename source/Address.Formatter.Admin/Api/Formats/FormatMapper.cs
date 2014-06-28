using System.Linq;
using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    public static class FormatMapper
    {
        const int MAX_LINES = 9;

        public static AddressFormat ToModel(this AddressFormatData data)
        {
            var model = new AddressFormat
                {
                    Id = data.Id,
                    Countries = data.Countries.Select(CountryMapper.ToModel),
                    Lines = data.Lines.Select(ToModel)
                };

            model.AllElements =
                new[]
                    {
                        "PersonName",
                        "CompanyName",
                        "Line1", "Line2", "Line3", "City", "State",
                        "CountryCode", "CountryName", "PostalCode"
                    }
                    .Where(p => p != "FormatIdentifier" && model.Lines.All(l => l.Elements.All(e => e.Name != p)))
                    .Select(p => new AddressFormatElement {Name = p})
                    .ToArray();

            model.Lines =
                model.Lines
                     .Concat(
                         Enumerable.Range(1, MAX_LINES)
                                   .Select(i => new AddressFormatLine())
                    ).Take(MAX_LINES);

            return model;
        }

        public static AddressFormatLine ToModel(this AddressFormatLineData data)
        {
            return new AddressFormatLine
                {
                    Elements = data.Elements.Select(ToModel),
                    ElementSeparator = data.ElementSeparator,
                    Prefix = data.Prefix,
                    Suffix = data.Suffix,
                    Trim = data.Trim
                };
        }

        public static AddressFormatElement ToModel(this AddressFormatElementData data)
        {
            return new AddressFormatElement
                {
                    Name = data.Name,
                    Prefix = data.Prefix,
                    Suffix = data.Suffix,
                    Trim = data.Trim,
                    ToUppercase = data.ToUppercase
                };
        }
    }
}