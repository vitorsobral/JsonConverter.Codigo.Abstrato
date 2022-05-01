using AutoBogus;
using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders
{
    public abstract class IncluirPessoaCommandBuilder<T> : AutoFaker<T> where T : IncluirPessoaCommand
    {
        public IncluirPessoaCommandBuilder<T> ComNome(string nome)
        {
            RuleFor(x => x.Nome, nome);
            return this;
        }

        public IncluirPessoaCommandBuilder<T> ComTipoPessoa(TipoPessoa tipoPessoa)
        {
            RuleFor(x => x.TipoPessoa, tipoPessoa);
            return this;
        }
    }
}
