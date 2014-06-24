using System;
using Xunit;

namespace Address.Formatter.Tests
{
    public class AddressFormatter_test
    {
        const string IDENTIFIER = "IDENTIFIER";

        [Fact]
        public void formats_address()
        {
            var service = new AddressFormatter(
                new[]
                    {
                        new AddressFormat
                            {
                                Identifier = IDENTIFIER,
                                Elements = new[]
                                    {
                                        new AddressFormatElement
                                            {
                                                NewLine = true,
                                                Name = "Line1",
                                                Prefix = "Prefix",
                                                Suffix = "Suffix"
                                            },
                                        new AddressFormatElement
                                            {
                                                NewLine = true,
                                                Name = "City",
                                                Prefix = "Prefix",
                                                Suffix = "Suffix"
                                            },
                                        new AddressFormatElement
                                            {
                                                NewLine = false,
                                                Prefix = "Prefix",
                                                Suffix = "Suffix",
                                                Name = "PostalCode"
                                            }
                                    }
                            }
                    });

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