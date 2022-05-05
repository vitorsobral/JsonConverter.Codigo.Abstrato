using JsonConverter.Código.Abstrato.Delegates;
using JsonConverter.Código.Abstrato.Domínio;
using JsonConverter.Código.Abstrato.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JsonConverter.Código.Abstrato
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection builder)
        {
            builder.AddScoped<PessoaFísicaService>();
            builder.AddScoped<PessoaJurídicaService>();

            builder.AddTransient<PessoaServiceResolver>(serviceProvider => tipoPessoa =>
            {
                return tipoPessoa switch
                {
                    TipoPessoa.Física => serviceProvider.GetRequiredService<PessoaFísicaService>(),
                    TipoPessoa.Jurídica => serviceProvider.GetRequiredService<PessoaJurídicaService>(),
                    _ => default,
                };
            });

            return builder;
        }
    }
}
