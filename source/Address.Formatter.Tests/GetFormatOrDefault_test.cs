using System.Collections.Generic;
using Xunit;

namespace Address.Formatter.Tests
{
    public class GetFormatOrDefault_test
    {
        const string IDENTIFIER = "IDENTIFIER";

        [Fact]
        public void returns_format_by_identifier()
        {
            var format = new AddressFormat();
            var result = AddressFormatter
                .GetFormatOrDefault(
                    IDENTIFIER,
                    new Dictionary<string, AddressFormat>
                        {
                            {IDENTIFIER, format}
                        });

            Assert.Equal(format, result);
        }

        [Fact]
        public void returns_default_format()
        {
            var format = new AddressFormat();
            var result = AddressFormatter
                .GetFormatOrDefault(
                    IDENTIFIER,
                    new Dictionary<string, AddressFormat>
                        {
                            {string.Empty, format}
                        });

            Assert.Equal(format, result);
        }

        [Fact]
        public void throws_when_not_found()
        {
            var format = new AddressFormat();
            Assert.Throws<AddressFormatNotFoundException>(
                () => AddressFormatter
                          .GetFormatOrDefault(
                              IDENTIFIER,
                              new Dictionary<string, AddressFormat>()
                          )
                );
        }
    }
}