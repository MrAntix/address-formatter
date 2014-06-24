using System;
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
                    GetLine1FormatLine(),
                    GetAddress(null)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_empty()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetLine1FormatLine(),
                    GetAddress(string.Empty)
                    ));
        }

        [Fact]
        public void returns_null_when_data_is_whitespace()
        {
            Assert.Null(
                AddressFormatter.GetLineData(
                    GetLine1FormatLine(),
                    GetAddress(" ")
                    ));
        }

        [Fact]
        public void adds_new_line()
        {
            var result = AddressFormatter.GetLineData(
                GetLine1FormatLine(),
                GetAddress()
                );

            Assert.Equal("PrefixLine1Suffix" + Environment.NewLine, result);
        }

        static IAddress GetAddress(string line1 = "Line1")
        {
            var mock = new Mock<IAddress>();
            mock.SetupGet(o => o.Line1).Returns(line1);

            return mock.Object;
        }

        static AddressFormatLine GetLine1FormatLine()
        {
            return new AddressFormatLine
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
                };
        }
    }
}