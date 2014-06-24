using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormatLine
    {
        readonly AddressFormatElement[] _elements;
        readonly string _elementSeparator;
        readonly string _prefix;
        readonly string _suffix;
        readonly bool _trim;

        public AddressFormatLine(
            AddressFormatElement[] elements,
            string elementSeparator,
            string prefix,
            string suffix,
            bool trim)
        {
            _elements = elements;
            _elementSeparator = elementSeparator;
            _prefix = prefix;
            _suffix = suffix;
            _trim = trim;
        }

        public string Prefix
        {
            get { return _prefix; }
        }

        public string Suffix
        {
            get { return _suffix; }
        }

        public AddressFormatElement[] Elements
        {
            get { return _elements; }
        }

        public bool Trim
        {
            get { return _trim; }
        }

        public string ElementSeparator
        {
            get { return _elementSeparator; }
        }
    }
}