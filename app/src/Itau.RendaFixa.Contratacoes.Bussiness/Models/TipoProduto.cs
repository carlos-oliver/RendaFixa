using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    public class TipoProduto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }
    }
}
