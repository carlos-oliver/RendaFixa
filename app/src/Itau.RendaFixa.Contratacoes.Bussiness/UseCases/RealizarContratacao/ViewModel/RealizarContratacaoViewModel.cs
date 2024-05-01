using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel
{
    public class RealizarContratacaoViewModel
    {
        public int IdContratante { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataOperacao { get; set; }
        public TimeSpan HoraOperacao { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "A {0} não pode ser negativa.")]
        public int Quantidade { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "O {0} não pode ser negativo.")]
        public double ValorUnitario { get; set; }
        public double ValorDesconto { get; set; }
        public bool PagaIntegralmente { get; set; }
    }
}
