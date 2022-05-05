using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Services;

namespace JsonConverter.Código.Abstrato.Delegates
{
    public delegate IPessoaService PessoaServiceResolver(TipoPessoa tipoPessoa);
}
