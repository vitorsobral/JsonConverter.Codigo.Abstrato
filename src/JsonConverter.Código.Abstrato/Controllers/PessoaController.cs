using JsonConverter.Código.Abstrato.Delegates;
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
        private readonly PessoaServiceResolver _pessoaServiceResolver;

        public PessoaController(ILogger<PessoaController> logger, PessoaServiceResolver pessoaServiceResolver)
        {
            _logger = logger;
            _pessoaServiceResolver = pessoaServiceResolver;
        }

        [HttpPost]
        public StatusCodeResult Post(IncluirPessoaCommand incluirPessoaCommand)
        {
            _logger.LogInformation("[HttpPost] PessoaController - Início do método");
            _logger.LogInformation($"[HttpPost] PessoaController - Tipo comando: {incluirPessoaCommand.TipoPessoa}");

            _pessoaServiceResolver(incluirPessoaCommand.TipoPessoa).Inserir(incluirPessoaCommand);

            return Ok();
        }
    }
}
