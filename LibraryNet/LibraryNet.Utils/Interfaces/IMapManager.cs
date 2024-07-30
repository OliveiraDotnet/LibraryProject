using AutoMapper;

namespace LibraryNet.Utils.Interfaces
{
    public interface IMapManager
    {
        IMapper Mapper { get; }
        IReadOnlyList<Profile> ConfiguredProfiles { get; }
        Action<IMapperConfigurationExpression> ActionInitialConfiguration { get; }
        void AddProfile<TPerfil>() where TPerfil : Profile, new();
        void AdditionalConfiguration();
    }
}