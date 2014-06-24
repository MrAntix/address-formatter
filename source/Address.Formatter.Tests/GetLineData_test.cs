using System;
using System.Collections.Generic;
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
                "PrefixSecond LineSuffix" + Environment.NewLine,
                AddressFormatter.GetLineData(
                    GetFormatLine(),
                    GetAddress(string.Empty, "Second Line")
                    ));
        }

        [Fact]
        public void adds_new_line()
        {
            var result = AddressFormatter.GetLineData(
                GetFormatLine(),
                GetAddress()
                );

            Assert.Equal("PrefixLine1SuffixPrefixLine2Suffix" + Environment.NewLine, result);
        }

        static IAddress GetAddress(
            string line1 = "Line1",
            string line2 = "Line2")
        {
            var mock = new Mock<IAddress>();
            mock.SetupGet(o => o.Line1).Returns(line1);
            mock.SetupGet(o => o.Line2).Returns(line2);

            return mock.Object;
        }

        static AddressFormatLine GetFormatLine()
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
                                },
                            new AddressFormatElement
                                {
                                    Name = "Line2",
                                    Prefix = "Prefix",
                                    Suffix = "Suffix"
                                }
                        }
                };
        }
    }
}