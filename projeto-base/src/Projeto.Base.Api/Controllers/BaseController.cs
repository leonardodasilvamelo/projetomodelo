using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Projeto.Base.Api.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class BaseController : ControllerBase
	{
		protected readonly ILogger _logger;

		protected BaseController(ILogger logger)
		{
			_logger = logger;
		}

		protected async Task<IActionResult> TratarResultadoAsync(Func<Task<IActionResult>> servico)
		{
			return await servico();
		}
	}
}
