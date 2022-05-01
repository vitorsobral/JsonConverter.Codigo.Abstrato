using Bogus.Extensions.Brazil;
using FluentAssertions;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands
{
    public class IncluirPessoaJurídicaCommandTestes : IncluirPessoaCommandTestes<IncluirPessoaJurídicaCommand, IncluirPessoaJurídicaCommandBuilder>
    {
        [Fact]
        public void IncluirPessoaJurídicaCommand_Deve_Estar_Preenchido_Corretamente()
        {
            var commandBuilder = new IncluirPessoaJurídicaCommandBuilder();
            var cnpj = faker.Company.Cnpj();

            commandBuilder.ComCnpj(cnpj);
            var command = commandBuilder.Generate();

            command.Cnpj.Should().Be(cnpj);
            command.TipoPessoa.Should().Be(TipoPessoa.Jurídica);
        }
    }
}
