using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Data.Dtos
{
    [Table("produtos")]
    public class CriarProdutoDto
    {
        [Column("id_tipo_produto")]
        public int IdTipoProduto { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("bloqueado")]
        public bool Bloqueado { get; set; }   
    }
}
