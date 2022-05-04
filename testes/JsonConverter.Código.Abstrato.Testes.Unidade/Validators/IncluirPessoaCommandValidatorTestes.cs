using Bogus;
using FluentValidation.TestHelper;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using JsonConverter.Código.Abstrato.Validators;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Validators
{
    public abstract class IncluirPessoaCommandValidatorTestes<T, Y>
        where T : IncluirPessoaCommand
        where Y : IncluirPessoaCommandBuilder<T>, new()
    {
        private readonly Faker faker = new Faker("pt_BR");
        protected IncluirPessoaCommandValidator<T> Validator;

        protected IncluirPessoaCommandValidatorTestes(IncluirPessoaCommandValidator<T> validator) => Validator = validator;

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Nome_Deve_Ser_Obrigatorio(string nome)
        {
            var commandBuilder = new Y();
            commandBuilder.ComNome(nome);

            Validator.TestValidate(commandBuilder.Generate())
                .ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("Nome é obrigatório");
        }
    }
}
