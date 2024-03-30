using Itau.RendaFixa.Contratacoes.Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Data
{
    public class ContratacoesContext : DbContext
    {
        public ContratacoesContext(DbContextOptions<ContratacoesContext> opts) : base(opts)
        {

        }
        public DbSet<TipoProdutoDto> ?TipoProdutos { get; set; }
    }

}
