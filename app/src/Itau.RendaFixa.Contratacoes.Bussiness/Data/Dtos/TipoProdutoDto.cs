using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos
{
    public class TipoProdutoDto
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
