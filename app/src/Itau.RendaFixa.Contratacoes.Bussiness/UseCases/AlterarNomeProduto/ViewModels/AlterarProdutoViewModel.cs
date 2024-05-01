using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels
{
    public class AlterarProdutoViewModel
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("id_tipo_produto")]
        public int IdTipoProduto { get; set; }

        [StringLength(50, MinimumLength = 20, ErrorMessage = "O nome deve ter entre 20 e 50 caracteres")]
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("bloqueado")]
        public bool Bloqueado { get; set; }
    }
}
