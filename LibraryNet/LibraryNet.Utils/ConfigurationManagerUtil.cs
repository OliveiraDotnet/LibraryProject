using LibraryNet.Utils.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LibraryNet.Utils
{
    public class ConfigurationManagerUtil : IConfigurationManagerUtil
    {
        protected virtual IConfiguration Configuration { get; }

        public ConfigurationManagerUtil(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetConfiguration(string key)
        {
            var values = Configuration.GetSection("Values");
            return values[key];
        }
    }
}