using Bogus;
using FluentAssertions;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands
{
    public abstract class IncluirPessoaCommandTestes<T, Y>
        where T : IncluirPessoaCommand
        where Y : IncluirPessoaCommandBuilder<T>, new()
    {
        protected readonly Faker faker = new("pt_BR");

        [Fact]
        public void IncluirPessoaCommand_Deve_Estar_Preenchido_Corretamente()
        {
            var commandBuilder = new Y();
            var nome = faker.Random.AlphaNumeric(10);

            commandBuilder.ComNome(nome);
            var command = commandBuilder.Generate();

            command.Nome.Should().Be(nome);
        }
    }
}
