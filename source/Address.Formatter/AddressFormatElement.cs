using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormatElement
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool ToUppercase { get; set; }
    }
}