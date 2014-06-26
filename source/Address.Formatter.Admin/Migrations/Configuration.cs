using System.Collections;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using Address.Formatter.Admin.Data;
using Address.Formatter.Admin.Data.Models;
using Address.Formatter.Admin.Resources;

namespace Address.Formatter.Admin.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Countries
                   .AddOrUpdate(o => o.ISO3,
                                CountryResources.ResourceManager
                                                .GetResourceSet(CultureInfo.CurrentUICulture, true, true)
                                                .Cast<DictionaryEntry>()
                                                .Select(entry => new CountryData
                                                    {
                                                        ISO3 = entry.Key.ToString()
                                                    })
                                                .ToArray()
                );
        }
    }
}