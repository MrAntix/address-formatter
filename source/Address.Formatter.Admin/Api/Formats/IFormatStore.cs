using System.Linq;
using System.Threading.Tasks;
using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    public interface IFormatStore
    {
        IQueryable<AddressFormatData> Query { get; }
        AddressFormatData Create();
        Task UpdateAsync(AddressFormatData data, AddressFormat model);
        Task Delete(int id);
    }
}