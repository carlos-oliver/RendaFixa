using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    [Table("contratacoes")]
    public class Contratacao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_contratante")]
        public int IdContratante { get; set;}

        [Column("id_produto")]
        public int IdProduto { get; set; }

        [Column("data_operacao")]
        public DateTime DataOperacao { get; set; }

        [Column("hora_operacao")]
        public TimeSpan HoraOperacao { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("valor_unitario")]
        public double ValorUnitario { get; set; }

        [Column("valor_desconto")]
        public double ValorDesconto { get; set; }

        [Column("paga_integralmente")]
        public bool PagaIntegralmente { get; set; } 

    }
}
