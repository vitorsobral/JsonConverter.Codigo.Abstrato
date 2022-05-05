using AutoBogus;
using FluentAssertions;
using JsonConverter.Código.Abstrato.Controllers;
using JsonConverter.Código.Abstrato.Delegates;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Controllers
{
    public class PessoaControllerTestes
    {
        private readonly Mock<ILogger<PessoaController>> _logger = new();
        private readonly Mock<PessoaServiceResolver> _pessoaServiceResolver = new();

        private readonly PessoaController _pessoaController;

        public PessoaControllerTestes() => _pessoaController = new PessoaController(_logger.Object, _pessoaServiceResolver.Object);

        [Theory]
        [MemberData(nameof(IncluirPessoaCommand))]
        public void Post_Deve_Loggar_Informações_E_Chamar_Inserir_Do_Serviço(IncluirPessoaCommand incluirPessoaCommand)
        {
            var pessoaService = new Mock<IPessoaService>();

            _pessoaServiceResolver
                .Setup(x => x.Invoke(incluirPessoaCommand.TipoPessoa))
                .Returns(pessoaService.Object);

            var response = _pessoaController.Post(incluirPessoaCommand);

            _logger.VerifyLog(x => x.LogInformation("[HttpPost] PessoaController - Início do método"));
            _logger.VerifyLog(x => x.LogInformation($"[HttpPost] PessoaController - Tipo comando: {incluirPessoaCommand.TipoPessoa}"));
            pessoaService.Verify(x => x.Inserir(incluirPessoaCommand));
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        public static readonly object[][] IncluirPessoaCommand = {
            new object[] { new AutoFaker<IncluirPessoaFísicaCommand>().Generate() },
            new object[] { new AutoFaker<IncluirPessoaJurídicaCommand>().Generate() }
        };
    }
}
