using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Api.ViewModels
{
    public class TipoProduto
    {
        [Key]
        public string? Nome { get; set; }
    }
}
