using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Address.Formatter.Tests
{
    public class AddressFormatter_test
    {
        const string IDENTIFIER = "IDENTIFIER";

        readonly IEnumerable<AddressFormat> _formats =
            new AddressFormatBuilder()
                .Address(
                    l => l.Line(e => e.Element(a => a.Line1, prefix: "Prefix", suffix: "Suffix"))
                          .Line(e => e.Element(a => a.City, prefix: "Prefix", suffix: "Suffix")
                                      .Element(a => a.PostalCode, prefix: "Prefix", suffix: "Suffix")),
                    IDENTIFIER)
                .Build();

        [Fact]
        public void formats_address()
        {
            var service = new AddressFormatter(_formats);

            var result = service.Format(new Address
                {
                    FormatIdentifier = IDENTIFIER,
                    Line1 = "Line1",
                    Line2 = "Line2",
                    City = "City",
                    PostalCode = "PostalCode"
                });

            Assert.Equal(
                "PrefixLine1Suffix" + Environment.NewLine
                + "PrefixCitySuffix PrefixPostalCodeSuffix",
                result
                );
        }

        [Fact]
        public void formats_address_postcode_on_new_line_when_city_missing()
        {
            var service = new AddressFormatter(_formats);

            var result = service.Format(new Address
                {
                    FormatIdentifier = IDENTIFIER,
                    Line1 = "Line1",
                    Line2 = "Line2",
                    PostalCode = "PostalCode"
                });

            Assert.Equal(
                "PrefixLine1Suffix" + Environment.NewLine
                + "PrefixPostalCodeSuffix",
                result
                );
        }

        [Fact]
        public void formatter_with_defaults()
        {
            var service = new AddressFormatter(AddressFormatSettings.Formats);

            Debug.Write(service.Format(
                new Address
                    {
                        FormatIdentifier = "BR",
                        PersonName = "Mr Harry Rashburn",
                        CompanyName = "Antix Software",
                        Line1 = "Itchington House",
                        Line2 = "Some Street",
                        City = "London",
                        PostalCode = "ab1 1ab",
                        CountryCode = "GB",
                        CountryName = "United Kingdom"
                    }));
        }

        public class Address : IAddress
        {
            public string PersonName { get; set; }
            public string CompanyName { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
            public string PostalCode { get; set; }
            public string FormatIdentifier { get; set; }
        }
    }
}