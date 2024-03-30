using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Data.Dtos
{
    [Table("tipos_produtos")]
    public class TipoProdutoDto
    {
        [Key]
        [Column("nome")]
        public string ?Nome { get; set; }
    }
}
