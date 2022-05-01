using FluentValidation;
using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Validators
{
    public class IncluirPessoaJurídicaCommandValidator : IncluirPessoaCommandValidator<IncluirPessoaJurídicaCommand>
    {
        public IncluirPessoaJurídicaCommandValidator()
        {
            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .WithMessage("CNPJ é obrigatório");
        }
    }
}
