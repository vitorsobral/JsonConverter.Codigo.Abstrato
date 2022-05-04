using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders
{
    public class IncluirPessoaJurídicaCommandBuilder : IncluirPessoaCommandBuilder<IncluirPessoaJurídicaCommand>
    {
        public IncluirPessoaJurídicaCommandBuilder ComCnpj(string cnpj)
        {
            RuleFor(x => x.Cnpj, cnpj);
            return this;
        }
    }
}
