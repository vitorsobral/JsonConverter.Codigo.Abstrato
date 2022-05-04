namespace JsonConverter.Código.Abstrato.Domínio
{
    public abstract class IncluirPessoaCommand
    {
        protected IncluirPessoaCommand(string nome) => Nome = nome;

        public string Nome { get; protected set; }

        public abstract TipoPessoa TipoPessoa { get; }
    }
}
