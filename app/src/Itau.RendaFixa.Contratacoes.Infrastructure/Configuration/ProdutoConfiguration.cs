using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Itau.RendaFixa.Contratacoes.Infrastructure.Configuration
{
    internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos")
                .HasKey(c => c.Id)
                .HasName("id");
        }
    }
}
