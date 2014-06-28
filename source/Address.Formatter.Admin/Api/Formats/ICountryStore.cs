using System.Linq;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    public interface ICountryStore
    {
        IQueryable<CountryData> Query { get; }
    }
}