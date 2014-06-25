using System.Collections.Generic;
using System.Linq;

namespace Address.Formatter
{
    public class AddressFormatLine
    {
        readonly AddressFormatElement[] _elements;
        readonly string _elementSeparator;
        readonly string _prefix;
        readonly string _suffix;
        readonly bool _trim;

        public AddressFormatLine(
            Settings settings)
        {
            _elements = settings.Elements.Select(o => new AddressFormatElement(o)).ToArray();
            _elementSeparator = settings.ElementSeparator;
            _prefix = settings.Prefix;
            _suffix = settings.Suffix;
            _trim = settings.Trim;
        }

        public class Settings
        {
            public Settings()
            {
                Elements = new AddressFormatElement.Settings[] {};
                ElementSeparator = " ";
                Trim = true;
            }

            public IEnumerable<AddressFormatElement.Settings> Elements { get; set; }
            public string ElementSeparator { get; set; }
            public string Prefix { get; set; }
            public string Suffix { get; set; }
            public bool Trim { get; set; }
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