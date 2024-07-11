using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels
{
    public class TipoProdutoViewModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
    }
}
