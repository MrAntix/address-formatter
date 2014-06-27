using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Address.Formatter.Admin.Api.Formats.Models;
using Address.Formatter.Admin.Data;
using Address.Formatter.Admin.Data.Models;

namespace Address.Formatter.Admin.Api.Formats
{
    public class FormatStore : IFormatStore
    {
        readonly DataContext _dataContext;

        public FormatStore(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<AddressFormatData> Query
        {
            get
            {
                return _dataContext.AddressFormats
                                   .Include(d => d.Countries)
                                   .Include(d => d.Lines.Select(dl => dl.Elements));
            }
        }

        public AddressFormatData Create()
        {
            var data = new AddressFormatData();
            _dataContext.AddressFormats.Add(data);

            return data;
        }

        public async Task UpdateAsync(AddressFormatData data, AddressFormat model)
        {
            await UpdateCountriesAsync(data, model.Countries.ToArray());
            UpdateLines(data, model.Lines.ToArray());

            await _dataContext.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var data = await Query.SingleAsync(d => d.Id == id);
            _dataContext.AddressFormats.Remove(data);

            await _dataContext.SaveChangesAsync();
        }

        async Task UpdateCountriesAsync(
            AddressFormatData data,
            IEnumerable<Country> models)
        {
            data.Countries.RemoveAll(cd =>
                                     models.All(cm => cm.Id != cd.Id));

            foreach (var cm in models)
            {
                var cmId = cm.Id;
                var cd = data.Countries
                             .SingleOrDefault(x => x.Id == cmId);
                if (cd != null) continue;

                cd = await _dataContext.Countries
                                       .SingleAsync(x => x.Id == cmId);
                data.Countries.Add(cd);
            }
        }

        void UpdateLines(
            AddressFormatData data,
            ICollection<AddressFormatLine> models)
        {
            var index = 0;
            for (; index < models.Count; index++)
            {
                var lineData = data.Lines.ElementAtOrDefault(index);
                if (lineData == null)
                {
                    data.Lines.Add(lineData = new AddressFormatLineData());
                }

                UpdateLine(
                    lineData, models.ElementAt(index)
                    );
            }

            for (; index < data.Lines.Count; index++)
            {
                data.Lines.RemoveAt(index);
            }
        }

        void UpdateLine(
            AddressFormatLineData data, AddressFormatLine model)
        {
            UpdateElements(data, model.Elements.ToArray());

            data.ElementSeparator = model.ElementSeparator;
            data.Prefix = model.Prefix;
            data.Suffix = model.Suffix;
            data.Trim = model.Trim;
        }

        void UpdateElements(
            AddressFormatLineData data,
            ICollection<AddressFormatElement> models)
        {
            var index = 0;
            for (; index < models.Count; index++)
            {
                var elementData = data.Elements.ElementAtOrDefault(index);
                if (elementData == null)
                {
                    data.Elements.Add(elementData = new AddressFormatElementData());
                }

                UpdateElement(
                    elementData, models.ElementAt(index)
                    );
            }

            for (; index < data.Elements.Count; index++)
            {
                data.Elements.RemoveAt(index);
            }
        }

        void UpdateElement(
            AddressFormatElementData data, AddressFormatElement model)
        {
            data.Name = model.Name;
            data.Prefix = model.Prefix;
            data.Suffix = model.Suffix;
            data.Trim = model.Trim;
            data.ToUppercase = model.ToUppercase;
        }
    }
}