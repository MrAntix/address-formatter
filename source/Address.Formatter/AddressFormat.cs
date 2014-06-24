using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormat
    {
        public string Identifier { get; set; }
        public AddressFormatLine[] Lines { get; set; }
    }
}