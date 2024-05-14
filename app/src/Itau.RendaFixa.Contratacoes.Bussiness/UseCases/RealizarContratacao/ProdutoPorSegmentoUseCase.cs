using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    // isto poderia ser um repository
    public class ProdutoPorSegmentoUseCase : IProdutoPorSegmentoUseCase
    {
        private readonly ContratacoesContext _context;
        public ProdutoPorSegmentoUseCase(ContratacoesContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidarProdutoPorSegmento(int idProduto, int idContrante, double valorUnitario, CancellationToken cancellationToken)
        {
            var valorTotal = TotalOperacaoEspecial(valorUnitario);
            var tipoSegmento = await ConsultarSegmentoContratante(idContrante);
            var tipoProduto = await ConsultarTipoProduto(idProduto);

            var segmento = tipoSegmento.FirstOrDefaultAsync().Result.Segmento.ToString();
            var produto = tipoProduto?.FirstOrDefaultAsync().Result.ToString();

            switch(segmento, produto)
            {
                case ("V", "CRI"):
                case ("V", "CRA"):
                case ("V", "DEV"):
                    return true;
                case ("A", "LCI"):
                case ("A", "LCA"):
                return true;
                case ("E", "CRI") when valorTotal:
                case ("E", "CRA") when valorTotal:
                case ("E", "DEV") when valorTotal:
                case ("E", "LCI") when valorTotal:
                case ("E", "LCA") when valorTotal:
                case ("E", "CDB") when valorTotal:
                    return true;
                default:
                    return false;
            }

        }

        public async Task<IQueryable<Contratante>> ConsultarSegmentoContratante(int idContrante)
        {
            var query = _context.Contratantes.AsQueryable();

            query = query.AsNoTracking()
                .Where(x => x.Id == idContrante);

            return query;
        }

        public async Task<IQueryable<string>> ConsultarTipoProduto(int idProduto)
        {
            var queryProdutos = _context.Produtos.AsQueryable();
            var queryTipoProdutos = _context.TipoProdutos.AsQueryable();

            var tipoProduto = queryProdutos.AsNoTracking()
                .Where(x => x.Id == idProduto)
                .Join(queryTipoProdutos.AsNoTracking(),
                p => p.IdTipoProduto,
                t => t.Id,
                (p, t) => t.Nome);

            return tipoProduto;
        }
        public bool TotalOperacaoEspecial(double valorTotal)
        {
            return valorTotal > 20000.00;
        }
    }
}
