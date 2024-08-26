using AutoMapper;
using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Repository.MongoDB.Extensions;
using LibraryNet.Core.Services;
using LibraryNet.Repository.EFCore;
using LibraryNet.Repository.EFCore.Repositories;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils;
using LibraryNet.Utils.DependencyInjection;
using LibraryNet.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LibraryNet.Repository.MongoDB.Repositories;

namespace LibraryNet.Web.Api.Application
{
    public class Factory : DependencyManager
    {
        public Factory(IServiceCollection services) : base(services)
        {
        }

        protected override void MapConfigure()
        {
            ServiceCollection.AddSingleton<IMapper>(AutoMapperManager.Instance.Mapper)
                             .AddSingleton<IConfigurationManagerUtil, ConfigurationManagerUtil>();
            //.AddSingleton<ICacheObjetos, CacheObjetosMemory>()

            var configuration = ServiceCollection.BuildServiceProvider().GetService<IConfiguration>();

            ServiceCollection.AddDbContext<LibraryContext>(o => o.UseLazyLoadingProxies()
                                                                 .UseSqlServer(configuration["SqlServerConnection"]));
            //Services
            ServiceCollection.AddScoped<IBookServices, BookServices>()
                             .AddScoped<IAuthorServices, AuthorServices>()
                             .AddScoped<IPublisherServices, PublishCompanyServices>();
            //Repositories
            ServiceCollection.AddScoped<IReadRepository<Repository.Models.Book>, BookRepository>()
                             .AddScoped<IWriteRepository<Repository.Models.Book>, BookRepository>()
                             .AddScoped<IReadRepository<Repository.Models.Author>, AuthorRepository>()
                             .AddScoped<IWriteRepository<Repository.Models.Author>, AuthorRepository>()
                             .AddScoped<IReadRepository<Repository.Models.Publisher>, PublishCompanyRepository>()
                             .AddScoped<IWriteRepository<Repository.Models.Publisher>, PublishCompanyRepository>()
                             .AddScoped<OrderRepositoryMongo>();

            ServiceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryNet.Web.Api", Version = "v1" });
                c.EnableAnnotations();
            });

            ServiceCollection.MongoClientRegister("MongoConnection");
        }
    }
}