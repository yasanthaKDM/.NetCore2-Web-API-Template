using Microsoft.Extensions.Configuration;
using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IModels;

namespace WebApiTemplate.WebAPI.Models
{
    public class ApplicationSettings : IApplicationSettings
    {

        private readonly IConfiguration _configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BasicAuth GetBasicAuth()
        {
            return new BasicAuth
            {
                UserName = _configuration.GetSection("BasicAuth").GetValue<string>("Username"),
                Password = _configuration.GetSection("BasicAuth").GetValue<string>("Password")
            };
        }
    }
}
