using LibraryNet.Repository.EFCore;
using LibraryNet.Utils;
using LibraryNet.Utils.DependencyInjection;
using LibraryNet.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LibraryNet.Web.Api.Application
{
    public class Factory : DependencyManager
    {
        public Factory(IServiceCollection services) : base(services)
        {
        }

        protected override void MapConfigure()
        {
            ServiceCollection.AddSingleton(MappingManager.Instance.Mapper)
                             .AddSingleton<IConfigurationManagerUtil, ConfigurationManagerUtil>();
            //.AddSingleton<ICacheObjetos, CacheObjetosMemory>()

            var configuration = ServiceCollection.BuildServiceProvider().GetService<IConfiguration>();
            var opcoes = new DbContextOptionsBuilder<LibraryContext>().UseLazyLoadingProxies().UseSqlServer(configuration["SqlServerConnection"])
                                                                      .Options;

            ServiceCollection.AddScoped<DbContext>(s => new LibraryContext(opcoes));

            ServiceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryNet.Web.Api", Version = "v1" });
                c.EnableAnnotations();
            });
        }
    }
}