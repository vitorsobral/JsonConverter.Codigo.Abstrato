using JsonConverter.Código.Abstrato.Domínio;

namespace JsonConverter.Código.Abstrato.Services
{
    public interface IPessoaService
    {
        void Inserir(IncluirPessoaCommand incluirPessoaCommand);
    }
}
