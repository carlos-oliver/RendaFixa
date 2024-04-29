using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao.ViewModel
{
    public class ConsultarContratacaoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int IdContratante { get; set; }
        public int IdProduto { get; set; }
        public DateOnly DataOperacao { get; set; }
        public TimeOnly HoraOperacao { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorDesconto { get; set; }
        public bool PagaIntegralmente { get; set; }
    }
}
