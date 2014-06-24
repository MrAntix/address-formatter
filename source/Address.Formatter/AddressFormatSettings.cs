using System.Collections.Generic;

namespace Address.Formatter
{
    public sealed partial class AddressFormatSettings
    {
        static AddressFormatSettings()
        {
            if (defaultInstance.Formats == null)
            {
                var builder = new AddressFormatSettingsBuilder();
                builder
                    .Add("GB",
                         f => f.Line(l => l.Element(a => a.PersonTitle, " ")
                                           .Element(a => a.PersonFirstName, " ")
                                           .Element(a => a.PersonMiddleName, " ")
                                           .Element(a => a.PersonLastName))
                               .Line(l => l.Element(a => a.CompanyName))
                               .Line(l => l.Element(a => a.Line1))
                               .Line(l => l.Element(a => a.Line2))
                               .Line(l => l.Element(a => a.Line3))
                               .Line(l => l.Element(a => a.City))
                               .Line(l => l.Element(a => a.State))
                               .Line(l => l.Element(a => a.CountryName))
                               .Line(l => l.Element(a => a.PostalCode, toUppercase: true))
                    )
                    .Add("NL",
                         f => f.Line(l => l.Element(a => a.PersonTitle, " ")
                                           .Element(a => a.PersonFirstName, " ")
                                           .Element(a => a.PersonMiddleName, " ")
                                           .Element(a => a.PersonLastName))
                               .Line(l => l.Element(a => a.CompanyName))
                               .Line(l => l.Element(a => a.Line1))
                               .Line(l => l.Element(a => a.Line2))
                               .Line(l => l.Element(a => a.Line3))
                               .Line(l => l.Element(a => a.PostalCode, "  ", toUppercase: true)
                                           .Element(a => a.City))
                               .Line(l => l.Element(a => a.State))
                               .Line(l => l.Element(a => a.CountryName))
                    );

                defaultInstance["Formats"] = new List<AddressFormat>(builder.Build());
            }
        }
    }
}