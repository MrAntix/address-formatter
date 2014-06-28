using System;
using System.Linq;
using Moq;
using Xunit;

namespace Address.Formatter.Tests
{
    public class GetLineData_test
    {
        [Fact]
        public void returns_null_when_data_is_null()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(null, null)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_empty()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(string.Empty, string.Empty)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_whitespace()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(" ", " ")
                    ));
        }

        [Fact]
        public void returns_line_any_not_null_empty_or_whitespace()
        {
            Assert.Equal(
                "PrefixXXXXSuffix" + Environment.NewLine,
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(string.Empty, "XXXX")
                    ));
        }

        [Fact]
        public void adds_new_line()
        {
            var result = AddressFormatter.GetLineData(
                GetFormatLine(),
                GetAddress()
                );

            Assert.Equal(
                "PrefixPersonNameSuffix PrefixCompanyNameSuffix" +
                Environment.NewLine, result);
        }

        [Fact]
        public void no_double_separator_when_element_null()
        {
            var result = AddressFormatter.GetLineData(
                GetFormatLine(),
                GetAddress(companyName: null)
                );

            Assert.Equal("PrefixPersonNameSuffix" + Environment.NewLine, result);
        }

        static IAddress GetAddress(
            string personName = "PersonName",
            string companyName = "CompanyName")
        {
            var mock = new Mock<IAddress>();
            mock.SetupGet(o => o.PersonName).Returns(personName);
            mock.SetupGet(o => o.CompanyName).Returns(companyName);

            return mock.Object;
        }

        static AddressFormatLine GetFormatLine()
        {
            return new AddressFormatBuilder.LineBuilder()
                .Line(e => e.Element(a => a.PersonName, prefix: "Prefix", suffix: "Suffix")
                            .Element(a => a.CompanyName, prefix: "Prefix", suffix: "Suffix"))
                .Build().Single();
        }
    }
}