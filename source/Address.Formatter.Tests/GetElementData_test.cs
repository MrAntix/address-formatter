using System;
using Moq;
using Xunit;

namespace Address.Formatter.Tests
{
    public class GetElementData_test
    {
        [Fact]
        public void returns_null_when_data_is_null()
        {
            Assert.Null(
                AddressFormatter.GetElementData(
                    GetLine1FormatElement(),
                    GetAddress(null)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_empty()
        {
            Assert.Null(
                AddressFormatter.GetElementData(
                    GetLine1FormatElement(),
                    GetAddress(string.Empty)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_whitespace()
        {
            Assert.Null(
                AddressFormatter.GetElementData(
                    GetLine1FormatElement(),
                    GetAddress(" ")
                    ));
        }

        [Fact]
        public void adds_new_line_prefix_and_suffix()
        {
            var result = AddressFormatter.GetElementData(
                GetLine1FormatElement(),
                GetAddress()
                );

            Assert.Equal(Environment.NewLine+"PrefixLine1Suffix" , result);
        }

        static IAddress GetAddress(string line1 = "Line1")
        {
            var mock = new Mock<IAddress>();
            mock.SetupGet(o => o.Line1).Returns(line1);

            return mock.Object;
        }

        static AddressFormatElement GetLine1FormatElement()
        {
            return new AddressFormatElement
                {
                    Name = "Line1",
                    Prefix = "Prefix",
                    Suffix = "Suffix",
                    NewLine = true
                };
        }
    }
}