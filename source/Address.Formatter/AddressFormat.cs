using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormat
    {
        readonly string[] _identifiers;
        readonly AddressFormatLine[] _lines;

        public AddressFormat(
            string[] identifiers, AddressFormatLine[] lines)
        {
            _identifiers = identifiers;
            _lines = lines;
        }

        public string[] Identifiers
        {
            get { return _identifiers; }
        }

        public AddressFormatLine[] Lines
        {
            get { return _lines; }
        }
    }
}