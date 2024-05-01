using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_tipo_produto")]
        public int IdTipoProduto { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("bloqueado")]
        public bool Bloqueado { get; set; }
    }
}
