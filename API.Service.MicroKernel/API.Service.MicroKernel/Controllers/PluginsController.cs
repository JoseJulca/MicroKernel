using Microsoft.AspNetCore.Mvc;
using API.Service.MicroKernel.Core;

namespace API.Service.MicroKernel.Controllers
{
    [ApiController]
    [Route("api/plugins")]
    public class PluginsController : ControllerBase
    {
        private readonly PluginManager _kernel;

        public PluginsController(PluginManager kernel) => _kernel = kernel;

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var result = _kernel.Run(name);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult List() => Ok(_kernel.ListPlugins());
    }
}
