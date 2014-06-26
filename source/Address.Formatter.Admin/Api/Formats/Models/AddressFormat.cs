using System.Linq;
using Address.Formatter.Admin.Data.Models;
using Address.Formatter.Admin.Resources;

namespace Address.Formatter.Admin.Api.Formats.Models
{
    public class AddressFormat
    {
        readonly AddressFormatData _data;

        public AddressFormat(AddressFormatData data)
        {
            _data = data;
        }

        public string Display
        {
            get
            {
                return _data.Countries.Any()
                           ? string.Join(", ", _data.Countries
                           .Select(c =>CountryResources.ResourceManager.GetString(c.ISO3)))
                           : "(default)";
            }
        }
    }
}