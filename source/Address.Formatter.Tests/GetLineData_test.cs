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
                    GetAddress(null, null, null, null)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_empty()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(string.Empty, string.Empty, string.Empty, string.Empty)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_whitespace()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(" ", " ", " ", " ")
                    ));
        }

        [Fact]
        public void returns_line_any_not_null_empty_or_whitespace()
        {
            Assert.Equal(
                "PrefixXXXXSuffix" + Environment.NewLine,
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(string.Empty, "XXXX", null, null)
                    ));
        }

        [Fact]
        public void adds_new_line()
        {
            var result = AddressFormatter.GetLineData(
                GetFormatLine(),
                GetAddress()
                );

            Assert.Equal("PrefixTitleSuffix PrefixFirstNameSuffix PrefixMiddleNameSuffix PrefixLastNameSuffix" + Environment.NewLine, result);
        }

        [Fact]
        public void no_double_separator_when_element_null()
        {
            var result = AddressFormatter.GetLineData(
                GetFormatLine(),
                GetAddress(middleName:null)
                );

            Assert.Equal("PrefixTitleSuffix PrefixFirstNameSuffix PrefixLastNameSuffix" + Environment.NewLine, result);
        }

        static IAddress GetAddress(
            string title = "Title",
            string firstName = "FirstName",
            string middleName = "MiddleName",
            string lastName = "LastName")
        {
            var mock = new Mock<IAddress>();
            mock.SetupGet(o => o.PersonTitle).Returns(title);
            mock.SetupGet(o => o.PersonFirstName).Returns(firstName);
            mock.SetupGet(o => o.PersonMiddleName).Returns(middleName);
            mock.SetupGet(o => o.PersonLastName).Returns(lastName);

            return mock.Object;
        }

        static AddressFormatLine GetFormatLine()
        {
            return new AddressFormatBuilder.LineBuilder()
                .Line(e => e.Element(a => a.PersonTitle, prefix: "Prefix", suffix: "Suffix")
                            .Element(a => a.PersonFirstName, prefix: "Prefix", suffix: "Suffix")
                            .Element(a => a.PersonMiddleName, prefix: "Prefix", suffix: "Suffix")
                            .Element(a => a.PersonLastName, prefix: "Prefix", suffix: "Suffix"))
                .Build().Single();
        }
    }
}