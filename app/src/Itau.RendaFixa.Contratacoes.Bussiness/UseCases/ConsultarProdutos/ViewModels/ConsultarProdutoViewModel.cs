using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels
{
    public class ConsultarProdutoViewModel
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Id_Tipo_Produto")]
        public int IdTipoProduto { get; set; }
        [JsonProperty("nome")]
        public string? Nome { get; set; }
        [JsonProperty("bloqueado")]
        public bool Bloqueado { get; set; }
    }
}
