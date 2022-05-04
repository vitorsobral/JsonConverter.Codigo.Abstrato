using JsonConverter.Código.Abstrato.Domínio;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonConverter.Código.Abstrato.Converters
{
    public class IncluirPessoaCommandJsonConverter : JsonConverter<IncluirPessoaCommand>
    {
        public override IncluirPessoaCommand Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var document))
            {
                var tipoPessoa = ExtrairTipoPessoa(document.RootElement);

                return tipoPessoa switch
                {
                    TipoPessoa.Física => JsonSerializer.Deserialize<IncluirPessoaFísicaCommand>(document.RootElement.GetRawText(), options),
                    TipoPessoa.Jurídica => JsonSerializer.Deserialize<IncluirPessoaJurídicaCommand>(document.RootElement.GetRawText(), options),
                    _ => throw new JsonException("Tipo pessoa inválido.")
                };
            }

            throw new JsonException("Não foi possível converter o valor recebido.");
        }

        public override void Write(Utf8JsonWriter writer, IncluirPessoaCommand value, JsonSerializerOptions options) => throw new NotImplementedException();

        private static TipoPessoa ExtrairTipoPessoa(JsonElement jsonElement)
        {
            var propriedade = jsonElement.EnumerateObject().FirstOrDefault(el => string.Compare(el.Name, "tipoPessoa", true) is 0);

            if (propriedade.Value.ValueKind != JsonValueKind.Undefined && propriedade.Value.TryGetInt32(out var tipoInstrucao))
            {
                if (!Enum.IsDefined(typeof(TipoPessoa), tipoInstrucao))
                    throw new JsonException("Tipo pessoa inválido.");

                return (TipoPessoa)tipoInstrucao;
            }

            throw new JsonException("Não é possível encontrar o tipo de pessoa.");
        }
    }
}
