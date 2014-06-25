namespace Address.Formatter
{
    public class AddressFormatElement
    {
        readonly string _name;
        readonly string _prefix;
        readonly string _suffix;
        readonly bool _trim;
        readonly bool _toUppercase;

        public AddressFormatElement(
            Settings settings)
        {
            _name = settings.Name;
            _prefix = settings.Prefix;
            _suffix = settings.Suffix;
            _toUppercase = settings.ToUppercase;
            _trim = settings.Trim;
        }

        public class Settings
        {
            public Settings()
            {
                Trim = true;
                ToUppercase = false;
            }

            public string Name { get; set; }
            public string Prefix { get; set; }
            public string Suffix { get; set; }
            public bool Trim { get; set; }
            public bool ToUppercase { get; set; }
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