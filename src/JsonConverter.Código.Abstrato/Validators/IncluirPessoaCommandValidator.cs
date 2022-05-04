using FluentValidation;
using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Validators
{
    public class IncluirPessoaCommandValidator<T> : AbstractValidator<T> where T : IncluirPessoaCommand
    {
        public IncluirPessoaCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.TipoPessoa)
                .IsInEnum()
                .WithMessage("Tipo de pessoa inválido");
        }
    }
}
