using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos
{
    public class ConsultarProdutoUseCase : IConsultarProdutoUseCase
    {
        private readonly IContratacaoDbContext _context;
        private readonly IMapper _mapper;

        public ConsultarProdutoUseCase(IContratacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ConsultarProdutoViewModel>>> ObterProdutoAsync(string? nome, int take, CancellationToken cancellationToken = default)
        {

            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(x => x.Nome!.ToLower() == nome.ToLower());

            var produtos = query.Take(take).ToList();
            // se utilizar a nomenclatura ViewModel, utilize somente elas, se Dto tbm so Dto
            var produtosDto = _mapper.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos);

            var response = new ApiResponse<IEnumerable<ConsultarProdutoViewModel>>
            {
                Data = new List<ConsultarProdutoViewModel>()
            };

            return response;
        }
    }
}
