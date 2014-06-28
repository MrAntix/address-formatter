using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Address.Formatter.Admin.Api.Formats.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    [Route("services/formats/countries")]
    public class CountriesController : ApiController
    {
        readonly ICountryStore _store;

        public CountriesController(ICountryStore store)
        {
            _store = store;
        }

        public async Task<IEnumerable<Country>> GetAll(bool availableOnly)
        {
            var data = await (availableOnly
                                  ? _store.Query
                                          .Where(c => c.AddressFormat == null)
                                  : _store.Query)
                                 .ToArrayAsync();

            return data
                .Select(d => d.ToModel())
                .OrderBy(d => d.Name)
                .ToArray();
        }
    }
}