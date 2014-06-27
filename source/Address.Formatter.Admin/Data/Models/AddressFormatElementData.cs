using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class AddressFormatElementData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool Trim { get; set; }
        public bool ToUppercase { get; set; }

        public class Configuration : EntityTypeConfiguration<AddressFormatElementData>
        {
            public Configuration()
            {
                ToTable("AddressFormatElements");
            }
        }
    }
}