using Microsoft.Extensions.DependencyInjection;
using LibraryNet.Utils.Interfaces;

namespace LibraryNet.Utils.DependencyInjection
{
    public class ApplicationInitializer
    {
        public static ApplicationInitializer Init(IServiceCollection services)
        {
            return new ApplicationInitializer(services);
        }

        protected internal DependencyManager Instance { get; set; }
        protected internal IServiceCollection Services { get; }
        protected ApplicationInitializer(IServiceCollection services)
        {
            Services = services;
        }

        public virtual ApplicationInitializer SetDependencyManager<T>(bool validateDependencyManager = true) where T : IDependencyManager
        {
            if (validateDependencyManager)
                DependencyManagerValidation();

            Instance = (DependencyManager)Activator.CreateInstance(typeof(T), Services);
            SetDependencyManagerInstance();
            return this;
        }
        public ApplicationInitializer SetMappingManager<T>() where T : IMapManager, new()
        {
            MappingManager.Inicializar<T>();
            return this;
        }
        public void Finish() => Instance.Finish();
        protected static void DependencyManagerValidation()
        {
            if (DependencyManager.Instance != null)
                throw new InvalidOperationException("GestorDependencia já inicializado, usar: GestorDependencia.Instancia");
        }
        protected virtual void SetDependencyManagerInstance()
        {
            DependencyManager.Instance = Instance;
        }
    }
}