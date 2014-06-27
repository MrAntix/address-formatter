using System.Linq;
using Address.Formatter.Admin.Data.Models;
using Address.Formatter.Admin.Resources;

namespace Address.Formatter.Admin.Api.Formats.Models
{
    public static class AddressFormatMapper
    {
        public static AddressFormat ToModel(this AddressFormatData data)
        {
            var model = new AddressFormat
                {
                    Id = data.Id,
                    Countries = data.Countries.Select(ToModel),
                    Lines = data.Lines.Select(ToModel)
                };

            model.AllElements =
                new[]
                    {
                        "PersonTitle", "PersonFirstName", "PersonMiddleName", "PersonLastName",
                        "CompanyName",
                        "Line1", "Line2", "Line3", "City", "State",
                        "CountryCode", "CountryName", "PostalCode"
                    }
                    .Where(p => p != "FormatIdentifier" && model.Lines.All(l => l.Elements.All(e => e.Name != p)))
                    .Select(p => new AddressFormatElement {Name = p})
                    .ToArray();

            if (model.Lines.Count() < 10)
            {
                model.Lines =
                    model.Lines
                         .Concat(
                             Enumerable.Range(1, 10)
                                       .Select(i => new AddressFormatLine())
                        ).Take(8);
            }

            return model;
        }

        public static Country ToModel(this CountryData data)
        {
            return new Country
                {
                    Id = data.Id,
                    Name = CountryResources.ResourceManager.GetString(data.ISO3)
                };
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