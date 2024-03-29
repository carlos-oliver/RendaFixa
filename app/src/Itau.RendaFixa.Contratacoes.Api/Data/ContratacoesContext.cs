using Itau.RendaFixa.Contratacoes.Api.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Api.Data
{
    public class ContratacoesContext : DbContext
    {
        public ContratacoesContext(DbContextOptions<ContratacoesContext> opts) : base(opts) 
        {

        }
        public DbSet<TipoProdutoDto> TipoProdutos { get; set; }
    }

}
