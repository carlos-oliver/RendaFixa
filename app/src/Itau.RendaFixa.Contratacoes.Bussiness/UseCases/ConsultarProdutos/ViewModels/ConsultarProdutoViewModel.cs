using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels
{
    public class ConsultarProdutoViewModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("Id_Tipo_Produto")]
        public int IdTipoProduto { get; set; }
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
        [JsonPropertyName("bloqueado")]
        public bool Bloqueado { get; set; }
    }
}
