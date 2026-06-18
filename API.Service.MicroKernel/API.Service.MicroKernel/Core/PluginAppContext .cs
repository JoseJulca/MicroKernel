namespace API.Service.MicroKernel.Core
{
    public class PluginAppContext : IAppContext
    {
        private readonly Dictionary<string, List<Action<object>>> _handlers = new();

        public void Log(string message) => Console.WriteLine($"[LOG] {message}");

        public void Publish(string eventName, object data)
        {
            if (_handlers.TryGetValue(eventName, out var list))
                foreach (var h in list) h(data);
        }

        public void Subscribe(string eventName, Action<object> handler)
        {
            _handlers.TryAdd(eventName, new List<Action<object>>());
            _handlers[eventName].Add(handler);
        }
    }
}
