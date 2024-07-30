namespace LibraryNet.Utils.Interfaces
{
    public interface IDependencyManager
    {
        object GetInstance(Type type);
        TInstance GetInstance<TInstance>() where TInstance : class;
        IDisposable CreateScope();
    }
}