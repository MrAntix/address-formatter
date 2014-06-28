using System.Linq;
using Address.Formatter.Admin.Data;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    public class CountryStore : ICountryStore
    {
        readonly DataContext _dataContext;

        public CountryStore(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<CountryData> Query
        {
            get { return _dataContext.Countries; }
        }
    }
}