using API.Service.MicroKernel.Core;
namespace API.Service.MicroKernel.Plugins
{
    public class RankingPlugin : IPlugin
    {
        public string Name => "ranking";
        private IAppContext _ctx = null!;

        public void Initialize(IAppContext context) => _ctx = context;

        public object Execute(object? input = null)
        {
            return new[] { "Alemania", "Argentina", "Francia", "España" };
        }
    }
}
