using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    public class Produto
    {
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
