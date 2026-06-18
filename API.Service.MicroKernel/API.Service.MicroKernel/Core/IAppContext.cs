namespace API.Service.MicroKernel.Core
{
    public interface IAppContext
    {
        void Log(string message);
        void Publish(string eventName, object data);
        void Subscribe(string eventName, Action<object> handler);
    }
}
