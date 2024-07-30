using AutoMapper;
using LibraryNet.Utils.Interfaces;
using LibraryNet.Utils.Validators;

namespace LibraryNet.Utils
{
    public abstract class MapManager : IMapManager
    {
        public static IMapManager Instance { get; protected set; }
        public static void Inicializar<T>() where T : IMapManager, new()
        {
            if (Instance != null)
                return;

            Instance = new T();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfileValidator>();
                cfg.ShouldMapProperty = p => p.GetGetMethod(true).IsPrivate || p.GetGetMethod(true).IsHideBySig;
                foreach (var p in Instance.ConfiguredProfiles)
                {
                    cfg.AddProfile(p);
                }
                Instance.ActionInitialConfiguration?.Invoke(cfg);
            });
            Instance.AdditionalConfiguration();
            ((MapManager)Instance).Mapper = config.CreateMapper();
        }
        protected MapManager()
        {
        }

        protected List<Profile> profilesList = new List<Profile>();
        public IMapper Mapper { get; protected set; }
        public IReadOnlyList<Profile> ConfiguredProfiles => profilesList.AsReadOnly();
        public abstract Action<IMapperConfigurationExpression> ActionInitialConfiguration { get; }

        public void AddProfile<IProfile>() where IProfile : Profile, new()
        {
            profilesList.Add(new IProfile());
        }
        public virtual void AdditionalConfiguration()
        {
        }
    }
    public abstract class MapManager<T> : MapManager where T : IMapManager, new()
    {
        public static void Initialize()
        {
            MapManager.Inicializar<T>();
        }

        public override Action<IMapperConfigurationExpression> ActionInitialConfiguration => null;
    }
}