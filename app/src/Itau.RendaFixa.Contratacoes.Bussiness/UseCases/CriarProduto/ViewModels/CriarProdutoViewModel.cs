using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels
{
    public class CriarProdutoViewModel
    {
        public int Id_Tipo_Produto { get; set; }

        [StringLength(50, MinimumLength = 20, ErrorMessage = "O nome deve ter entre 20 e 50 caracteres")]
        public string? Nome { get; set; }

        public bool Bloqueado { get; set; }
    }
}
