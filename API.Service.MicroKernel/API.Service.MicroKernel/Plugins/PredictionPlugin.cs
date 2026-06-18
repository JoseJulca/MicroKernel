using API.Service.MicroKernel.Core;
namespace API.Service.MicroKernel.Plugins
{
    public class PredictionPlugin : IPlugin
    {
        public string Name => "prediction";
        private IAppContext _ctx = null!;

        public void Initialize(IAppContext context)
        {
            _ctx = context;
            _ctx.Subscribe("MatchPlayed", data => _ctx.Log($"Predicción evaluada contra: {data}"));
        }

        public object Execute(object? input = null)
        {
            return new { Campeon = "Argentina", Confianza = "78%" };
        }
    }
}
