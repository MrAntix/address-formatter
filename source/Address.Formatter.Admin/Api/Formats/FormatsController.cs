using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    [Route("services/formats")]
    public class FormatsController : ApiController
    {
        readonly IFormatStore _store;

        public FormatsController(IFormatStore store)
        {
            _store = store;
        }

        public async Task<IEnumerable<AddressFormat>> GetAll()
        {
            var data = await _store.Query
                                   .ToArrayAsync();

            return data
                .Select(d => d.ToModel())
                .OrderBy(d => d.Display)
                .ToArray();
        }

        public async Task Post(AddressFormat model)
        {
            var data = default(AddressFormatData);
            if (model.Id > 0)
            {
                data = await _store.Query
                                   .FirstOrDefaultAsync(d => d.Id == model.Id);
            }

            if (data == null)
            {
                data = _store.Create();
            }

            await _store.UpdateAsync(data, model);
        }

        public async Task Delete(int id)
        {
            await _store.Delete(id);
        }
    }
}