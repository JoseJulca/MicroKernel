namespace API.Service.MicroKernel.Core
{
    public interface IPlugin
    {
        string Name { get; }
        void Initialize(IAppContext context);
        object Execute(object? input = null);
    }
}
