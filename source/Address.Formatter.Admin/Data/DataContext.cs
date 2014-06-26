using System.Data.Entity;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<AddressFormatData> AddressFormats { get; set; }
    }
}