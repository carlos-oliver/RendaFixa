using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos
{
    public class ObterTipoProdutoUseCase : IObterTipoProdutoUseCase
    {
        private readonly IContratacaoDbContext _context;
        private readonly IMapper _mapper;

        public ObterTipoProdutoUseCase(IContratacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TipoProdutoViewModel>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            //var tipoProdutos = await _context.TipoProdutos.ToListAsync(cancellationToken);
            //
            //var viewModels = _mapper.Map<List<TipoProdutoViewModel>>(tipoProdutos);

            var response = new ApiResponse<List<TipoProdutoViewModel>>
            {
                Data = new List<TipoProdutoViewModel>()
            };

            return response;
        }
    }
}
