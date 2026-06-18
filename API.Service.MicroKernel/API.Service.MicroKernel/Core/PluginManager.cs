namespace API.Service.MicroKernel.Core
{
    public class PluginManager
    {
        private readonly Dictionary<string, IPlugin> _plugins = new();
        private readonly IAppContext _context;

        public PluginManager(IAppContext context) => _context = context;

        public void Register(IPlugin plugin)
        {
            plugin.Initialize(_context);
            _plugins[plugin.Name.ToLower()] = plugin;
            _context.Log($"Plugin registrado: {plugin.Name}");
        }

        public object Run(string pluginName, object? input = null)
        {
            if (!_plugins.TryGetValue(pluginName.ToLower(), out var plugin))
                throw new KeyNotFoundException($"Plugin '{pluginName}' no encontrado");

            return plugin.Execute(input);
        }

        public IEnumerable<string> ListPlugins() => _plugins.Keys;
    }
}
