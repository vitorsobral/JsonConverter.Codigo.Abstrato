using AutoBogus;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Services
{
    public class PessoaJurídicaServiceTestes : PessoaServiceTestes<PessoaJurídicaService, IncluirPessoaJurídicaCommand>
    {
        [Fact]
        public void Inserir_Deve_Chamar_Validar_E_Loggar_Informações()
        {
            var incluirPessoaCommand = new AutoFaker<IncluirPessoaJurídicaCommand>().Generate();

            _pessoaService.Inserir(incluirPessoaCommand);

            _logger.VerifyLog(x => x.LogInformation("[Validar] PessoaJurídicaService - Início do método"));
            _logger.VerifyLog(x => x.LogInformation($"[Validar] PessoaJurídicaService - Tipo comando: {incluirPessoaCommand.TipoPessoa}"));
        }
    }
}
