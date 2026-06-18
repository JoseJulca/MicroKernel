using API.Service.MicroKernel.Core;
namespace API.Service.MicroKernel.Plugins
{
    public class MatchScorePlugin : IPlugin
    {
        public string Name => "matchscore";
        private IAppContext _ctx = null!;

        public void Initialize(IAppContext context) => _ctx = context;

        public object Execute(object? input = null)
        {
            var result = new { Local = "Argentina", Visitante = "Argelia", Marcador = "3-0" };
            _ctx.Publish("MatchPlayed", result);
            return result;
        }
    }
}
