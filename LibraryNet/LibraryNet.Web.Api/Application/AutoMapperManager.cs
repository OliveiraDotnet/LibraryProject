using AutoMapper;
using LibraryNet.Core.Configuration;
using LibraryNet.Repository.Configuration;
using LibraryNet.Utils;

namespace LibraryNet.Web.Api.Application
{
    public class AutoMapperManager : MappingManager
    {
        public AutoMapperManager()
        {
            AddProfile<MappingProfileCore>();
            AddProfile<MappingProfileRepository>();
        }

        public override Action<IMapperConfigurationExpression> ActionInitialConfiguration => c => { };
    }
}