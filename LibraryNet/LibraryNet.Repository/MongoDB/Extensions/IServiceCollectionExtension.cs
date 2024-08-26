using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Security.Authentication;

namespace LibraryNet.Repository.MongoDB.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection MongoClientRegister(this IServiceCollection services, string mongoConnection)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var connection = sp.GetService<IConfiguration>().GetConnectionString(mongoConnection);
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connection));
                settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                
                return new MongoClient(settings);
            });
            return services;
        }
    }
}