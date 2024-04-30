using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel
{
    public class RealizarContratacaoViewModel
    {
        public int Id_Contratante { get; set; }
        public int Id_Produto { get; set; }
        public DateTime Data_Operacao { get; set; }
        public TimeSpan Hora_Operacao { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "A {0} não pode ser negativa.")]
        public int Quantidade { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "O {0} não pode ser negativo.")]
        public double Valor_Unitario { get; set; }
        public double Valor_Desconto { get; set; }
        public bool Paga_Integralmente { get; set; }
    }
}
