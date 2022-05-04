using JsonConverter.Código.Abstrato.Domínio;
using Microsoft.Extensions.Logging;

namespace JsonConverter.Código.Abstrato.Services
{
    public abstract class PessoaService : IPessoaService
    {
        protected readonly ILogger<PessoaService> _logger;

        public PessoaService(ILogger<PessoaService> logger) => _logger = logger;

        public void Inserir(IncluirPessoaCommand incluirPessoaCommand)
        {
            _logger.LogInformation("[Inserir] PessoaService - Início do método");
            _logger.LogInformation($"[Inserir] PessoaService - Tipo comando: {incluirPessoaCommand.TipoPessoa}");
            Validar(incluirPessoaCommand);
        }

        protected abstract void Validar(IncluirPessoaCommand incluirPessoaCommand);
    }
}
