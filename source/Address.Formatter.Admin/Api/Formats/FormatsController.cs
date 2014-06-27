using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data;

namespace Address.Formatter.Admin.Api.Formats
{
    [Route("services/formats")]
    public class FormatsController : ApiController
    {
        readonly DataContext _dataContext;

        public FormatsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<AddressFormat>> GetAll()
        {
            var data = await _dataContext.AddressFormats
                                         .Include(d => d.Countries)
                                         .Include(d => d.Lines.Select(dl => dl.Elements))
                                         .ToArrayAsync();

            return data
                .Select(d => d.ToModel())
                .OrderBy(d => d.Display)
                .ToArray();
        }
    }
}