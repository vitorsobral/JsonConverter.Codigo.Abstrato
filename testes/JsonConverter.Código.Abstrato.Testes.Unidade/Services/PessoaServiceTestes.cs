using AutoBogus;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Services
{
    public abstract class PessoaServiceTestes<T, Y>
        where T : PessoaService
        where Y : IncluirPessoaCommand
    {
        protected readonly T _pessoaService;
        protected readonly Mock<ILogger<T>> _logger = new();

        public PessoaServiceTestes() => _pessoaService = (T)Activator.CreateInstance(typeof(T), _logger.Object);

        [Fact]
        public void Inserir_Deve_Loggar_Informações()
        {
            var incluirPessoaCommand = new AutoFaker<Y>().Generate();

            _pessoaService.Inserir(incluirPessoaCommand);

            _logger.VerifyLog(x => x.LogInformation("[Inserir] PessoaService - Início do método"));
            _logger.VerifyLog(x => x.LogInformation($"[Inserir] PessoaService - Tipo comando: {incluirPessoaCommand.TipoPessoa}"));
        }
    }
}
