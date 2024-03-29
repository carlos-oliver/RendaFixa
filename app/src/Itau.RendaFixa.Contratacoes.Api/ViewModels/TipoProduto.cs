using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Api.ViewModels
{
    public class TipoProduto
    {
        [Key]
        public string ?Nome { get; set; }
    }
}