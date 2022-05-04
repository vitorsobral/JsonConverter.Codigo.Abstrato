using FluentValidation.TestHelper;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using JsonConverter.Código.Abstrato.Validators;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Validators
{
    public class IncluirPessoaFísicaCommandValidatorTestes : IncluirPessoaCommandValidatorTestes<IncluirPessoaFísicaCommand, IncluirPessoaFísicaCommandBuilder>
    {
        public IncluirPessoaFísicaCommandValidatorTestes() : base(new IncluirPessoaFísicaCommandValidator()) { }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Cpf_Deve_Ser_Obrigatorio(string cpf)
        {
            var commandBuilder = new IncluirPessoaFísicaCommandBuilder();
            commandBuilder.ComCpf(cpf);

            Validator.TestValidate(commandBuilder.Generate())
                .ShouldHaveValidationErrorFor(x => x.Cpf)
                .WithErrorMessage("CPF é obrigatório");
        }
    }
}
