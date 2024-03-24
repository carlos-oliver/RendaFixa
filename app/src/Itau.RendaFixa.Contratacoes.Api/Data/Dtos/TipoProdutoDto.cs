using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Api.Data.Dtos
{
    [Table("tipos_produtos")]
    public class TipoProdutoDto
    {
        [Key]
        [Column("nome")]
        public string Nome { get; set; }
    }
}
