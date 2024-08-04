using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness
{
    public class DefaultResultViewModel
    {
        [JsonPropertyName("data")]
        public object? Data { get;}
        [JsonPropertyName("erros")]
        public IEnumerable<Notification>? Erros { get; set; }

        public DefaultResultViewModel()
        {
        }

        public DefaultResultViewModel(object? data)
        {
            Data = data;
        }

        public DefaultResultViewModel(IEnumerable<Notification>? erros)
        {
            Erros = erros;
        }
        public DefaultResultViewModel(object? data, IEnumerable<Notification>? erros)
        {
            Data = data;
            Erros = erros;
        }
    }
}
