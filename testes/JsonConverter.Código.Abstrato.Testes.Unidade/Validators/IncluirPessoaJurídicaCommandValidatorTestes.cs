using FluentValidation.TestHelper;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders;
using JsonConverter.Código.Abstrato.Validators;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Validators
{
    public class IncluirPessoaJurídicaCommandValidatorTestes : IncluirPessoaCommandValidatorTestes<IncluirPessoaJurídicaCommand, IncluirPessoaJurídicaCommandBuilder>
    {
        public IncluirPessoaJurídicaCommandValidatorTestes() : base(new IncluirPessoaJurídicaCommandValidator()) { }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Cpf_Deve_Ser_Obrigatorio(string cnpj)
        {
            var commandBuilder = new IncluirPessoaJurídicaCommandBuilder();
            commandBuilder.ComCnpj(cnpj);

            Validator.TestValidate(commandBuilder.Generate())
                .ShouldHaveValidationErrorFor(x => x.Cnpj)
                .WithErrorMessage("CNPJ é obrigatório");
        }
    }
}
