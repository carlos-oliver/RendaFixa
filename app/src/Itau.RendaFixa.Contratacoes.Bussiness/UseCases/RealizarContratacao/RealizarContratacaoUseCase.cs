using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Extensions;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public class RealizarContratacaoUseCase : IRealizarContratacaoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IContratacaoDbContext _context;
        private readonly IContratacaoRepository _contratacaoRepository;
        private readonly IConsultarProdutoRepository _consultarProdutoRepository;
        private readonly IConsultarContratanteRepository _consultarContratanteRepository;
        private readonly IConsultarTipoProdutoRepository _consultarTipoProdutoRepository;
        public RealizarContratacaoUseCase(
            IMapper mapper,
            IContratacaoDbContext context,
            IContratacaoRepository contratacaoRepository,
            IConsultarProdutoRepository consultarProdutoRepository,
            IConsultarContratanteRepository consultarContratanteRepository,
            IConsultarTipoProdutoRepository consultarTipoProdutoRepository)
        {
            _mapper = mapper;
            _context = context;
            _contratacaoRepository = contratacaoRepository;
            _consultarProdutoRepository = consultarProdutoRepository;
            _consultarContratanteRepository = consultarContratanteRepository;
            _consultarTipoProdutoRepository = consultarTipoProdutoRepository;
        }
        public async Task<(HttpStatusCode, DefaultResultViewModel<Contratacao>)> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default)
        {
            //var data = DateTime.Now;
            //if (data.DiasUteis())
            //    return default;

            //if (!HorarioContratacao())
            //    return default;

            //var teste = await _consultarProdutoBloqueadoUseCase.ConsultarProduto();

            //como nao ha dependencias nessas consultar poderimos fazer a mesma de forma concorrente com Task.WhenAll()
            //erro A second operation was started on this context instance before a previous operation completed"
            //var tasks = new Task<bool>[]
            //{
            //    ConsultarProdutoPorId(realizarContratacaoViewModel.IdProduto, cancellationToken),
            //    ConsultarContratantePorId(realizarContratacaoViewModel.IdContratante, cancellationToken)
            //    ValidarProdutoPorSegmento(realizarContratacaoViewModel.IdProduto, realizarContratacaoViewModel.IdContratante, realizarContratacaoViewModel.ValorUnitario, cancellationToken)
            //};

            //var resultados = await Task.WhenAll(tasks);

            //if (resultados.Any(x => !x))
            //    return default;

            if (!await ConsultarProdutoPorId(realizarContratacaoViewModel.IdProduto, cancellationToken))
                return default;

            if (!await ConsultarContratantePorId(realizarContratacaoViewModel.IdContratante, cancellationToken))
                return default;

            if (!await ValidarProdutoPorSegmento(realizarContratacaoViewModel.IdProduto, realizarContratacaoViewModel.IdContratante, realizarContratacaoViewModel.ValorUnitario, cancellationToken))
                return default;

            if (ValidarDesconto(realizarContratacaoViewModel))
                return default;

            var contratacao = _mapper.Map<Contratacao>(realizarContratacaoViewModel);
            
            await _contratacaoRepository.CriarAsync(contratacao, cancellationToken);
            
            return (HttpStatusCode.Created, new DefaultResultViewModel<Contratacao>(contratacao));
        }
        public static bool ValidarDesconto(RealizarContratacaoViewModel realizarContratacaoViewModel)
        {
            if (realizarContratacaoViewModel.ValorDesconto > 
               (realizarContratacaoViewModel.Quantidade * realizarContratacaoViewModel.ValorUnitario))
                return true;

            return default;
        }
        public bool HorarioContratacao()
        {
            var horarioAtual = DateTime.Now.TimeOfDay;

            var inicio = new TimeSpan(01, 30, 0);
            var fim = new TimeSpan(23, 59, 0);

            return horarioAtual >= inicio && horarioAtual <= fim;
        }
        public async Task<bool> ConsultarProdutoPorId(int id, CancellationToken cancellationToken = default)
        {
            var query = await _consultarProdutoRepository.ConsultarPorIdAsync(id, cancellationToken);
            if (query!.Bloqueado)
                return default;

            return true;
        }
        public async Task<bool> ConsultarContratantePorId(int idContrante, CancellationToken cancellationToken = default)
        {
            var query = await _consultarContratanteRepository.ConsultarAsync(idContrante, cancellationToken);
            if(!query!.Habilitado)
                return default;

            return true;
        }
        public async Task<bool> ValidarProdutoPorSegmento(int idProduto, int idContrante, double valorUnitario, CancellationToken cancellationToken)
        {
            var valorTotal = TotalOperacaoEspecial(valorUnitario);
            var tipoSegmento = await ConsultarSegmentoContratante(idContrante, cancellationToken);
            var tipoProduto = await ConsultarTipoProduto(idProduto);
            
            switch(tipoSegmento, tipoProduto)
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

        public async Task<string> ConsultarSegmentoContratante(int idContrante, CancellationToken cancellationToken = default)
        {
            var contratante = await _consultarContratanteRepository.ConsultarAsync(idContrante, cancellationToken);

            return contratante!.Segmento;
        }
        public async Task<string?> ConsultarTipoProduto(int idProduto, CancellationToken cancellationToken = default)
        {
            var queryProdutos = await _consultarProdutoRepository.ConsultarAsync(cancellationToken);
            var queryTipoProdutos = await _consultarTipoProdutoRepository.ConsultarAsync(cancellationToken);

            var tipoProduto = queryProdutos
                .Where(x => x.Id == idProduto)
                .Join(queryTipoProdutos,
                    p => p.IdTipoProduto,
                    t => t.Id,
                    (p, t) => t.Nome);

            return tipoProduto.FirstOrDefault();
        }
        public static bool TotalOperacaoEspecial(double valorTotal)
        {
            return valorTotal > 20000.00;
        }
    }
}
