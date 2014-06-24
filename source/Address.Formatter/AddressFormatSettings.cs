using System;
using System.Collections.Generic;

namespace Address.Formatter
{
    public sealed partial class AddressFormatSettings
    {
        static AddressFormatSettings()
        {
            if (defaultInstance.Formats == null)
            {
                var builder = new AddressFormatBuilder();
                builder
                    .Address(
                        f => f.Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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
                              .Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName)),
                        "BG"

                    )
                    .Address(
                        f => f.Line(l => l.Element(a => a.CompanyName))
                              .Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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
                        f => f.Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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
                        f => f.Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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
                        f => f.Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
                              .Line(l => l.Element(a => a.CompanyName))
                              .Line(l => l.Element(a => a.Line1))
                              .Line(l => l.Element(a => a.Line2))
                              .Line(l => l.Element(a => a.Line3))
                              .Line(l => l.Element(a => a.City))
                              .Line(l => l.Element(a => a.State))
                              .Line(l => l.Element(a => a.CountryName))
                              .Line(l => l.Element(a => a.PostalCode, toUppercase: true)),
                        "GB"
                    )
                    .Address(
                        f => f.Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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
                              .Line(l => l.Element(a => a.PersonTitle)
                                          .Element(a => a.PersonFirstName)
                                          .Element(a => a.PersonMiddleName)
                                          .Element(a => a.PersonLastName))
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

                defaultInstance["Formats"] = new List<AddressFormat>(builder.Build());
            }
        }
    }
}