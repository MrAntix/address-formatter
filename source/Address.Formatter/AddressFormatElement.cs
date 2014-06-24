using System;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormatElement
    {
        readonly string _name;
        readonly string _prefix;
        readonly string _suffix;
        readonly bool _trim;
        readonly bool _toUppercase;

        public AddressFormatElement(
            string name,
            string prefix, string suffix,
            bool trim, bool toUppercase)
        {
            _name = name;
            _prefix = prefix;
            _suffix = suffix;
            _toUppercase = toUppercase;
            _trim = trim;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Prefix
        {
            get { return _prefix; }
        }

        public string Suffix
        {
            get { return _suffix; }
        }

        public bool ToUppercase
        {
            get { return _toUppercase; }
        }

        public bool Trim
        {
            get { return _trim; }
        }
    }
}