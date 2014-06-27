using System.Collections.Generic;
using System.Linq;

namespace Address.Formatter.Admin.Api.Formats.Models
{
    public class AddressFormat
    {
        public string Display
        {
            get
            {
                return Countries.Any()
                           ? string.Join(", ", Countries.Select(d => d.Name))
                           : "(default)";
            }
        }

        public int Id { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<AddressFormatLine> Lines { get; set; }

        public IEnumerable<AddressFormatElement> AllElements { get; set; }
    }
}