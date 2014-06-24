using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormat
    {
        readonly string _identifier;
        readonly AddressFormatLine[] _lines;

        public AddressFormat(
            string identifier, AddressFormatLine[] lines)
        {
            _identifier = identifier;
            _lines = lines;
        }

        public string Identifier
        {
            get { return _identifier; }
        }

        public AddressFormatLine[] Lines
        {
            get { return _lines; }
        }
    }
}