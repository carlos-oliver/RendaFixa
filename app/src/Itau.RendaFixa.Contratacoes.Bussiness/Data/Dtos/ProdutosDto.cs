using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos
{
    public class ProdutosDto
    {
        [Key]
        public int Id { get; set; }

        public int IdTipoProduto { get; set; }

        public string? Nome { get; set; }

        public bool Bloqueado { get; set; }
    }
}
