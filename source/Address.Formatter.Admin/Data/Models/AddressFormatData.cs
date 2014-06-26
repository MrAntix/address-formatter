using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class AddressFormatData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CountryData> Countries { get; set; }

        public class Configuration : EntityTypeConfiguration<AddressFormatData>
        {
            public Configuration()
            {
                ToTable("AddressFormats");

                Property(o => o.Name).HasMaxLength(50);
                Property(o => o.Description).HasMaxLength(400);
                HasMany(o => o.Countries).WithMany();
            }
        }
    }
}