using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class AddressFormatLineData
    {
        public int Id { get; set; }
        public List<AddressFormatElementData> Elements { get; set; }
        public string ElementSeparator { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool Trim { get; set; }

        public class Configuration : EntityTypeConfiguration<AddressFormatLineData>
        {
            public Configuration()
            {
                ToTable("AddressFormatLines");

                HasMany(o => o.Elements).WithRequired();
            }
        }
    }
}