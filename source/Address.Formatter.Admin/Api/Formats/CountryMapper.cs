using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data.Models;
using Address.Formatter.Admin.Resources;

namespace Address.Formatter.Admin.Api.Formats
{
    public static class CountryMapper
    {
        public static Country ToModel(this CountryData data)
        {
            return new Country
                {
                    Id = data.Id,
                    Name = CountryResources.ResourceManager.GetString(data.ISO3)
                };
        }
    }
}