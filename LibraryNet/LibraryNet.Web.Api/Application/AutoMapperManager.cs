using AutoMapper;
using LibraryNet.Core.Configuration;
using LibraryNet.Utils;

namespace LibraryNet.Web.Api.Application
{
    public class AutoMapperManager : MappingManager
    {
        public AutoMapperManager()
        {
            AddProfile<MappingProfileCore>();
        }

        public override Action<IMapperConfigurationExpression> ActionInitialConfiguration => c => { };
    }
}