using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Address.Formatter.Tests
{
    public class AddressFormatter_test
    {
        readonly IEnumerable<AddressFormat> _formats =
            new[]
                {
                    new AddressFormat
                        {
                            Identifier = IDENTIFIER,
                            Lines = new[]
                                {
                                    new AddressFormatLine
                                        {
                                            Elements = new[]
                                                {
                                                    new AddressFormatElement
                                                        {
                                                            Name = "Line1",
                                                            Prefix = "Prefix",
                                                            Suffix = "Suffix"
                                                        }
                                                }
                                        },
                                    new AddressFormatLine
                                        {
                                            Elements = new[]
                                                {
                                                    new AddressFormatElement
                                                        {
                                                            Name = "City",
                                                            Prefix = "Prefix",
                                                            Suffix = "Suffix"
                                                        },
                                                    new AddressFormatElement
                                                        {
                                                            Prefix = "Prefix",
                                                            Suffix = "Suffix",
                                                            Name = "PostalCode"
                                                        }
                                                }
                                        }
                                }
                        }
                };

        const string IDENTIFIER = "IDENTIFIER";

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
                + "PrefixCitySuffixPrefixPostalCodeSuffix",
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
            var service = new AddressFormatter(AddressFormatSettings.Default.Formats);

            Debug.Write(service.Format(
                new Address
                    {
                        FormatIdentifier = "GB",
                        PersonTitle = "Mr",
                        PersonFirstName = "Harry",
                        PersonLastName = "Rashburn",
                        CompanyName = "Antix Software",
                        Line1 = "Itchington House",
                        Line2 = "Some Street",
                        City = "London",
                        PostalCode = "ab1 1ab",
                        CountryName = "United Kingdom"
                    }));
        }

        public class Address : IAddress
        {
            public string PersonTitle { get; set; }
            public string PersonFirstName { get; set; }
            public string PersonMiddleName { get; set; }
            public string PersonLastName { get; set; }
            public string CompanyName { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string CountryName { get; set; }
            public string PostalCode { get; set; }
            public string FormatIdentifier { get; set; }
        }
    }
}