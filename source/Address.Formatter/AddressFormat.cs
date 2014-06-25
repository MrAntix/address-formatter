using System.Collections.Generic;
using System.Linq;

namespace Address.Formatter
{
    public class AddressFormat
    {
        readonly string[] _identifiers;
        readonly AddressFormatLine[] _lines;

        public AddressFormat(
            Settings settings)
        {
            _identifiers = settings.Identifiers.ToArray();
            _lines = settings.Lines.Select(o => new AddressFormatLine(o)).ToArray();
        }

        public class Settings
        {
            public Settings()
            {
                Identifiers = new string[] {};
                Lines = new AddressFormatLine.Settings[] {};
            }

            public IEnumerable<string> Identifiers { get; set; }
            public IEnumerable<AddressFormatLine.Settings> Lines { get; set; }
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