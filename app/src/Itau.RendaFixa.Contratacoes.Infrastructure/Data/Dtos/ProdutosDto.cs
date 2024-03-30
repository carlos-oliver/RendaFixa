using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Data.Dtos
{
    [Table("produtos")]
    public class ProdutosDto
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
