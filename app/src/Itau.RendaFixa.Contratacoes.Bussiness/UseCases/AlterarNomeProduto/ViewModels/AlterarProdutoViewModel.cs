using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels
{
    public class AlterarProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int IdTipoProduto { get; set; }

        public string? Nome { get; set; }

        public bool Bloqueado { get; set; }
    }
}
