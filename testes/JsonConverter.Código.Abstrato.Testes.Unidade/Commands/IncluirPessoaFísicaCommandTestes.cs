using Bogus.Extensions.Brazil;
using FluentAssertions;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands
{
    public class IncluirPessoaFísicaCommandTestes : IncluirPessoaCommandTestes<IncluirPessoaFísicaCommand, IncluirPessoaFísicaCommandBuilder>
    {
        [Fact]
        public void IncluirPessoaFísicaCommand_Deve_Estar_Preenchido_Corretamente()
        {
            var commandBuilder = new IncluirPessoaFísicaCommandBuilder();
            var cpf = faker.Person.Cpf();

            commandBuilder.ComCpf(cpf);
            var command = commandBuilder.Generate();

            command.Cpf.Should().Be(cpf);
            command.TipoPessoa.Should().Be(TipoPessoa.Física);
        }
    }
}
