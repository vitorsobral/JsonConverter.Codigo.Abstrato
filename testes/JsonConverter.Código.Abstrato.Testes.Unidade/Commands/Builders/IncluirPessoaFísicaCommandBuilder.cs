using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Commands.Builders
{
    public class IncluirPessoaFísicaCommandBuilder : IncluirPessoaCommandBuilder<IncluirPessoaFísicaCommand>
    {
        public IncluirPessoaFísicaCommandBuilder ComCpf(string cpf)
        {
            RuleFor(x => x.Cpf, cpf);
            return this;
        }
    }
}
