using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels
{
    public class TipoProdutoViewModel
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string? Nome { get; set; }
    }
}
