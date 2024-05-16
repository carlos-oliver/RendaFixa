using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    // isto poderia ser um repository
    public class ProdutoPorSegmentoUseCase : IProdutoPorSegmentoUseCase
    {
        private readonly IContratacaoDbContext _context;
        public ProdutoPorSegmentoUseCase(IContratacaoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidarProdutoPorSegmento(int idProduto, int idContrante, double valorUnitario, CancellationToken cancellationToken)
        {
            var valorTotal = TotalOperacaoEspecial(valorUnitario);
            var tipoSegmento = ConsultarSegmentoContratante(idContrante);
            var tipoProduto = ConsultarTipoProduto(idProduto);

            //var produto = tipoProduto?.FirstOrDefaultAsync().Result.ToString();
//
            //switch(segmento, produto)
            //{
            //    case ("V", "CRI"):
            //    case ("V", "CRA"):
            //    case ("V", "DEV"):
            //        return true;
            //    case ("A", "LCI"):
            //    case ("A", "LCA"):
            //    return true;
            //    case ("E", "CRI") when valorTotal:
            //    case ("E", "CRA") when valorTotal:
            //    case ("E", "DEV") when valorTotal:
            //    case ("E", "LCI") when valorTotal:
            //    case ("E", "LCA") when valorTotal:
            //    case ("E", "CDB") when valorTotal:
            //        return true;
            //    default:
            //        return false;
            //}
            return true;
        }

        public string ConsultarSegmentoContratante(int idContrante)
            => _context.Contratantes.Single(x => x.Id == idContrante).Segmento;

        public string ConsultarTipoProduto(int idProduto)
        {
            return string.Empty;

            //var queryProdutos = _context.Produtos.AsQueryable();
            //var queryTipoProdutos = _context.TipoProdutos.AsQueryable();
//
            //var tipoProduto = queryProdutos.AsNoTracking()
            //    .Where(x => x.Id == idProduto)
            //    .Join(queryTipoProdutos.AsNoTracking(),
            //    p => p.IdTipoProduto,
            //    t => t.Id,
            //    (p, t) => t.Nome);
//
            //return tipoProduto;
        }
        public bool TotalOperacaoEspecial(double valorTotal)
        {
            return valorTotal > 20000.00;
        }
    }
}
