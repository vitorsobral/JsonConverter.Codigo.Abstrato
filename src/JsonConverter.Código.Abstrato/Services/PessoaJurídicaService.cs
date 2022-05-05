using JsonConverter.Código.Abstrato.Domínio;
using Microsoft.Extensions.Logging;

namespace JsonConverter.Código.Abstrato.Services
{
    public class PessoaJurídicaService : PessoaService
    {
        public PessoaJurídicaService(ILogger<PessoaService> logger) : base(logger) { }

        protected override void Validar(IncluirPessoaCommand incluirPessoaCommand)
        {
            _logger.LogInformation("[Validar] PessoaJurídicaService - Início do método");
            _logger.LogInformation($"[Validar] PessoaJurídicaService - Tipo comando: {incluirPessoaCommand.TipoPessoa}");
        }
    }
}
