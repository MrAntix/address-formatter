namespace Address.Formatter.Admin.Api.Formats.Models
{
    public class AddressFormatElement
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool Trim { get; set; }
        public bool ToUppercase { get; set; }
    }
}