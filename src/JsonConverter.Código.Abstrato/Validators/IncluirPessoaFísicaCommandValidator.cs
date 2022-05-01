using FluentValidation;
using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Validators
{
    public class IncluirPessoaFísicaCommandValidator : IncluirPessoaCommandValidator<IncluirPessoaFísicaCommand>
    {
        public IncluirPessoaFísicaCommandValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF é obrigatório");
        }
    }
}
