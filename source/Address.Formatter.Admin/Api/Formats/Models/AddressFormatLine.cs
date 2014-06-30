using System.Collections.Generic;

namespace Address.Formatter.Admin.Api.Formats.Models
{
    public class AddressFormatLine
    {
        public AddressFormatLine()
        {
            Elements = new AddressFormatElement[] {};
            ElementSeparator = " ";
        }

        public IEnumerable<AddressFormatElement> Elements { get; set; }
        public string ElementSeparator { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool Trim { get; set; }
    }
}