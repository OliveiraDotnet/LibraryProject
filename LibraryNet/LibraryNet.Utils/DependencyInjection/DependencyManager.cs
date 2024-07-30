using LibraryNet.Utils.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryNet.Utils.DependencyInjection
{
    public abstract class DependencyManager : IDependencyManager
    {
        public static IDependencyManager Instance { get; protected internal set; }
        protected internal IServiceCollection ServiceCollection { get; set; }
        protected internal ServiceProvider Container { get; set; }
        protected ISet<Type> Additional { get; } = new HashSet<Type>();
        protected DependencyManager(IServiceCollection services)
        {
            ServiceCollection = services;
        }

        public virtual object GetInstance(Type tipo)
        {
            return Container.GetService(tipo);
        }
        public virtual TInstancia GetInstance<TInstancia>() where TInstancia : class
        {
            return Container.GetService<TInstancia>();
        }
        public virtual IDisposable CreateScope()
        {
            return Container.CreateScope();
        }
        protected internal abstract void MapConfigure();
        protected internal virtual void Attach<T>() where T : IDependencyManager
        {
            var type = typeof(T);
            if (!type.IsSubclassOf(typeof(DependencyManager)))
                throw new ArgumentException($"Tipo {type.FullName} deve herdar de GestorDependencia.");
            Additional.Add(type);
        }
        protected virtual DependencyManager AdditionalInit(Type type)
        {
            return (DependencyManager)Activator.CreateInstance(type, ServiceCollection);
        }
        protected internal virtual void Finish()
        {
            MapConfigure();
            foreach (var type in Additional)
            {
                var g = AdditionalInit(type);
                g.MapConfigure();
            }
            Container = ServiceCollection.BuildServiceProvider();
        }
    }
    public abstract class DependencyManager<T> : DependencyManager where T : IDependencyManager, new()
    {
        public static T Initialize()
        {
            if (Instance != null)
                throw new InvalidOperationException("GestorDependencia já inicializado, usar: DependencyManager.Instance");

            var instance = new T();
            Instance = instance;
            return instance;
        }

        protected DependencyManager() : base(new ServiceCollection())
        {
        }
        protected DependencyManager(IServiceCollection services) : base(services)
        {
        }
        protected internal override void MapConfigure()
        {
        }
    }
}