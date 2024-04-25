using System.ComponentModel.DataAnnotations;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels
{
    public class CriarContratanteViewModel
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 150 caracteres")]
        public string? Nome { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 250 caracteres")]
        public string? Sobrenome { get; set; }
        
        [Required]
        [EnumDataType(typeof(TipoSegmento),ErrorMessage = "Segmento inválido Varejo (V), Atacado (A), Especial (E)")]
        public string? Segmento { get; set; }
        
        [Required]
        public bool Habilitado { get; set; }
    }

    public enum TipoSegmento
    {
        V = 'V',
        A = 'A',
        E = 'E'
    }
}
