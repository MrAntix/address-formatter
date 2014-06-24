using System;
using System.Runtime.Serialization;

namespace Address.Formatter
{
    [Serializable]
    public class AddressFormatNotFoundException : Exception
    {
        readonly string _identifier;

        public AddressFormatNotFoundException(string identifier) :
            base(string.Format(
                AddressFormatResources.AddressFormatNotFoundException_message,
                identifier))

        {
            _identifier = identifier;
        }

        protected AddressFormatNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public string Identifier
        {
            get { return _identifier; }
        }
    }
}