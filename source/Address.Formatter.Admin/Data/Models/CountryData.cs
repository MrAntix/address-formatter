using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class CountryData
    {
        public int Id { get; set; }
        public string ISO3 { get; set; }
        public List<AddressFormatData> AddressFormats { get; set; }

        public class Configuration : EntityTypeConfiguration<CountryData>
        {
            public Configuration()
            {
                ToTable("Counties");

                Property(o => o.ISO3).HasMaxLength(3);
                HasMany(o => o.AddressFormats).WithMany();
            }
        }
    }
}