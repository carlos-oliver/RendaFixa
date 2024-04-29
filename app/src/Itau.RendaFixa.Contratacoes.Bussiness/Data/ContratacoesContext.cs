using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Data
{
    public class ContratacoesContext : DbContext
    {
        public ContratacoesContext(DbContextOptions<ContratacoesContext> opts) : base(opts)
        {

        }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Contratante> Contratantes { get; set; }
        public DbSet<Contratacao> Contratacoes { get; set; }
    }
}
