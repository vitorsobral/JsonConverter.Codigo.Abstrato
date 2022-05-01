using JsonConverter.Código.Abstrato.Domínio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JsonConverter.Código.Abstrato.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger) => _logger = logger;

        [HttpPost]
        public StatusCodeResult Post(IncluirPessoaCommand incluirPessoaCommand)
        {
            _logger.LogInformation("[HttpPost] PessoaController - Início do método");
            _logger.LogInformation($"[HttpPost] PessoaController - Tipo comando: {incluirPessoaCommand.TipoPessoa}");

            return Ok();
        }
    }
}
