using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class AddressFormatData
    {
        public AddressFormatData()
        {
            Countries = new List<CountryData>();
        }

        public int Id { get; set; }

        public List<CountryData> Countries { get; set; }

        public class Configuration : EntityTypeConfiguration<AddressFormatData>
        {
            public Configuration()
            {
                ToTable("AddressFormats");

                HasMany(o => o.Countries).WithMany();
            }
        }
    }
}