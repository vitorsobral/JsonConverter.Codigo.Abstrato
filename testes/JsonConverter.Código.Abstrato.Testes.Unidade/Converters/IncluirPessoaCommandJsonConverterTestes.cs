using FluentAssertions;
using JsonConverter.Código.Abstrato.Converters;
using JsonConverter.Código.Abstrato.Domínio;
using System;
using System.Text;
using System.Text.Json;
using Xunit;

namespace JsonConverter.Código.Abstrato.Testes.Unidade.Converters
{
    public class IncluirPessoaCommandJsonConverterTestes
    {
        private readonly IncluirPessoaCommandJsonConverter conversor = new();

        [Fact]
        public void CanConvert_DeveRetornarTrue_QuandoTipoInformadoForIncluirPessoaCommand()
            => conversor.CanConvert(typeof(IncluirPessoaCommand)).Should().BeTrue();

        [Fact]
        public void CanConvert_DeveRetornarFalse_ParaTiposQueNaoForemIncluirPessoaCommand()
            => conversor.CanConvert(typeof(IncluirPessoaCommandJsonConverterTestes)).Should().BeFalse();

        [Theory]
        [InlineData(TipoPessoa.Física, typeof(IncluirPessoaFísicaCommand))]
        [InlineData(TipoPessoa.Jurídica, typeof(IncluirPessoaJurídicaCommand))]
        public void Read_DeveRelizarAConversaoDeTiposCorretamente(TipoPessoa tipoPessoa, Type tipoASerConvertido)
        {
            var json = $"{{\"tipoPessoa\": {(int)tipoPessoa} }}";

            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));

            var incluirPessoaCommand = conversor.Read(ref reader, typeof(IncluirPessoaCommand), new JsonSerializerOptions());

            incluirPessoaCommand.Should().BeOfType(tipoASerConvertido);
        }

        [Theory]
        [InlineData("{}")]
        [InlineData(@"{ ""tipoPessoa"": 0 }")]
        [InlineData(@"{ ""nao_tem_tipoPessoa"": 333 }")]
        public void Read_DeveLancarJsonException_QuandoJsonRecebidoForInvalido(string jsonInvalido)
        {
            Action act = () =>
            {
                var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(jsonInvalido));
                conversor.Read(ref reader, typeof(IncluirPessoaCommand), new JsonSerializerOptions());
            };

            act.Should().ThrowExactly<JsonException>();
        }
    }
}
