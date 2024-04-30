using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels
{
    public class ConsultarProdutoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Id_Tipo_Produto { get; set; }
        public string? Nome { get; set; }
        public bool Bloqueado { get; set; }
    }
}
