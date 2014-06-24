using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormatLine
    {
        public AddressFormatElement[] Elements { get; set; }
    }
}