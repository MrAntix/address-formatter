using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Address.Formatter.Admin.Configuration
{
    public class WebApiConfig
    {
        public static void Init(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();

            config.Formatters.Clear();
            config.Formatters.Add(formatter);
        }
    }
}