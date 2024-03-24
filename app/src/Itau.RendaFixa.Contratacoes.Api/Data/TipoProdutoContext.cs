using Itau.RendaFixa.Contratacoes.Api.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Api.Data
{
    public class TipoProdutoContext : DbContext
    {
        public TipoProdutoContext(DbContextOptions<TipoProdutoContext> opts) : base(opts) 
        {

        }

        public DbSet<TipoProdutoDto> TipoProdutos { get; set; }
    }

}
