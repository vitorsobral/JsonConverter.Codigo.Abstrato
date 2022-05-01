namespace JsonConverter.Código.Abstrato.Domínio
{
    public class IncluirPessoaJurídicaCommand : IncluirPessoaCommand
    {
        public IncluirPessoaJurídicaCommand(string nome, string cnpj) : base(nome) => Cnpj = cnpj;

        public string Cnpj { get; protected set; }

        public override TipoPessoa TipoPessoa => TipoPessoa.Jurídica;
    }
}
