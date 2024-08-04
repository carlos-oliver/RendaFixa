using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness
{
    public class DefaultResultViewModel<T>
    {
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("data")]
        public T? Data { get;}
        [JsonPropertyName("erros")]
        public IEnumerable<Notification>? Erros { get; set; }

        public DefaultResultViewModel()
        {
        }

        public DefaultResultViewModel(T? data)
        {
            Data = data;
        }

        public DefaultResultViewModel(IEnumerable<Notification>? erros)
        {
            Erros = erros;
        }
        public DefaultResultViewModel(T? data, IEnumerable<Notification>? erros)
        {
            Data = data;
            Erros = erros;
        }
    }
}
