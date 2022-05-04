using JsonConverter.Código.Abstrato.Domínio;
using Microsoft.Extensions.Logging;

namespace JsonConverter.Código.Abstrato.Services
{
    public class PessoaFísicaService : PessoaService
    {
        public PessoaFísicaService(ILogger<PessoaService> logger) : base(logger) { }

        protected override void Validar(IncluirPessoaCommand incluirPessoaCommand)
        {
            _logger.LogInformation("[Validar] PessoaFísicaService - Início do método");
            _logger.LogInformation($"[Validar] PessoaFísicaService - Tipo comando: {incluirPessoaCommand.TipoPessoa}");
        }
    }
}
