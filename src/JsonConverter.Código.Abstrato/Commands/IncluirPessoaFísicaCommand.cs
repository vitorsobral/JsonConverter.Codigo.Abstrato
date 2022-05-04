namespace JsonConverter.Código.Abstrato.Domínio
{
    public class IncluirPessoaFísicaCommand : IncluirPessoaCommand
    {
        public IncluirPessoaFísicaCommand(string nome, string cpf) : base(nome) => Cpf = cpf;

        public string Cpf { get; protected set; }

        public override TipoPessoa TipoPessoa => TipoPessoa.Física;
    }
}
