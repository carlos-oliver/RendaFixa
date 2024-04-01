using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels
{
    public class TipoProdutoViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
