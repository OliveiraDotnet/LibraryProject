using AutoMapper;
using LibraryNet.Utils;

namespace LibraryNet.Web.Api.Application
{
    public class AutoMapperManager : MappingManager
    {
        public AutoMapperManager()
        {
            //AddProfile<ApiPerfilMapeamento>();
        }

        public override Action<IMapperConfigurationExpression> ActionInitialConfiguration => c => { };
    }
}