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
        public ApplicationInitializer AnexerOutroGestorDependencia<T>() where T : DependencyManager
        {
            if (Instance == null)
                throw new InvalidOperationException("GestorDependencia principal deve ser inicializado primeiro chame SetarGestorDependencia.");
            Instance.Attach<T>();
            return this;
        }
        public ApplicationInitializer SetarGestorMapeamento<T>() where T : IMapManager, new()
        {
            MapManager.Inicializar<T>();
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