using System.Data.Entity.ModelConfiguration;

namespace Address.Formatter.Admin.Data.Models
{
    public class CountryData
    {
        public int Id { get; set; }
        public string ISO3 { get; set; }
        public AddressFormatData AddressFormat { get; set; }

        public class Configuration : EntityTypeConfiguration<CountryData>
        {
            public Configuration()
            {
                ToTable("Counties");

                Property(o => o.ISO3).HasMaxLength(3);
                HasOptional(o => o.AddressFormat)
                    .WithMany(o => o.Countries)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}