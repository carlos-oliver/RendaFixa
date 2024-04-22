using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels
{
    public class AlterarProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int IdTipoProduto { get; set; }

        [StringLength(50, MinimumLength = 20, ErrorMessage = "O nome deve ter entre 20 e 50 caracteres")]
        public string Nome { get; set; }

        public bool Bloqueado { get; set; }
    }
}
