using System;
using System.Collections.Generic;

namespace Address.Formatter
{
    public sealed class AddressFormatSettings
    {
        static IEnumerable<AddressFormat> _formats;

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/cc195167.aspx
        /// </summary>
        static IEnumerable<AddressFormat> GetFormats()
        {
            var builder = new AddressFormatBuilder();
            builder
                .Address(
                    f => f.Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.City))
                          .Line(l => l.Element(a => a.State))
                          .Line(l => l.Element(a => a.CountryName))
                          .Line(l => l.Element(a => a.PostalCode, toUppercase: true)),
                    string.Empty, "GB"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.City, suffix: ",")
                                      .Element(a => a.State)
                                      .Element(a => a.PostalCode))
                          .Line(l => l.Element(a => a.CountryName)),
                    "AU"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.CountryName))
                          .Line(l => l.Element(a => a.State))
                          .Line(l => l.Element(a => a.PostalCode)
                                      .Element(a => a.City))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.PersonName)),
                    "BG"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.PostalCode)
                                      .Element(a => a.City)
                                      .Element(a => a.State))
                          .Line(l => l.Element(a => a.CountryName)),
                    "BR"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.City, suffix: ",")
                                      .Element(a => a.State)
                                      .Element(a => a.PostalCode))
                          .Line(l => l.Element(a => a.CountryName)),
                    "CA"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.City))
                          .Line(l => l.Element(a => a.PostalCode)
                                      .Element(a => a.State))
                          .Line(l => l.Element(a => a.CountryName)),
                    "CN"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(l => l.Element(a => a.PostalCode, toUppercase: true)
                                      .Element(a => a.City), elementSeparator: "  ")
                          .Line(l => l.Element(a => a.State))
                          .Line(l => l.Element(a => a.CountryName)),
                    "NL", "BE"
                )
                .Address(
                    f => f.Line(l => l.Element(a => a.CompanyName))
                          .Line(l => l.Element(a => a.PersonName))
                          .Line(l => l.Element(a => a.Line1))
                          .Line(l => l.Element(a => a.Line2))
                          .Line(l => l.Element(a => a.Line3))
                          .Line(
                              l =>
                              l.Element(a => a.CountryCode, toUppercase: true, prefix: Environment.NewLine,
                                        suffix: "-")
                               .Element(a => a.PostalCode, toUppercase: true)
                               .Element(a => a.City, prefix: " "), elementSeparator: ""),
                    "DE"
                );

            return builder.Build();
        }

        public static IEnumerable<AddressFormat> Formats
        {
            get { return _formats ?? (_formats = GetFormats()); }
        }
    }
}