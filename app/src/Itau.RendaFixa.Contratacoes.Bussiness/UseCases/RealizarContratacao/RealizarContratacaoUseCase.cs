using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public class RealizarContratacaoUseCase : IRealizarContratacaoUseCase
    {
        private readonly IConsultarProdutoBloqueadoUseCase _consultarProdutoBloqueadoUseCase;
        private readonly IConsultarContratanteBloqueadoUseCase _consultarContratanteBloqueadoUseCase;
        private readonly IProdutoPorSegmentoUseCase _produtoPorSegmentoUseCase;
        private readonly IMapper _mapper;
        //private readonly ContratacoesContext _context;
        private readonly IContratacaoRepository _contratacaoRepository;

        public RealizarContratacaoUseCase(
            //ContratacoesContext context,
            IContratacaoRepository contratacaoRepository,
            IMapper mapper, 
            IConsultarProdutoBloqueadoUseCase consultarProdutoBloqueadoUseCase,
            IConsultarContratanteBloqueadoUseCase consultarContratanteBloqueado, 
            IProdutoPorSegmentoUseCase produtoPorSegmentoUseCase)
        {
            //_context = context;
            _contratacaoRepository = contratacaoRepository;
            _mapper = mapper;
            _consultarProdutoBloqueadoUseCase = consultarProdutoBloqueadoUseCase;
            _consultarContratanteBloqueadoUseCase = consultarContratanteBloqueado;
            _produtoPorSegmentoUseCase = produtoPorSegmentoUseCase;
        }

        public async Task<Contratacao> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default)
        {

            // acredito que isso aqui e um teste
            if (DiasUteis(DateTime.Parse("2024-05-08")))
                return null;

            //if (!HorarioContratacao())
            //    return null;

            // como nao ha dependencias nessas consultar poderimos fazer a mesma de forma concorrente com Task.WhenAll()
            //var tasks = new Task<bool>[] 
            //{
            //    _consultarProdutoBloqueadoUseCase.ConsultarProduto(realizarContratacaoViewModel.IdProduto),
            //    _consultarContratanteBloqueadoUseCase.ConsultarContratante(realizarContratacaoViewModel.IdContratante),
            //    _produtoPorSegmentoUseCase.ValidarProdutoPorSegmento(realizarContratacaoViewModel.IdProduto, realizarContratacaoViewModel.IdContratante, realizarContratacaoViewModel.ValorUnitario)
            //};
            //
            //var resultados = await Task.WhenAll(tasks);

            //if (resultados.Any(x => !x))
            //    return default;

            if (await _consultarProdutoBloqueadoUseCase.ConsultarProduto(realizarContratacaoViewModel.IdProduto))
                return null;

            if (!await _consultarContratanteBloqueadoUseCase.ConsultarContratante(realizarContratacaoViewModel.IdContratante))
                return null;

            if (!await _produtoPorSegmentoUseCase.ValidarProdutoPorSegmento(realizarContratacaoViewModel.IdProduto, realizarContratacaoViewModel.IdContratante, realizarContratacaoViewModel.ValorUnitario))
                return null;

            if (ValidarDesconto(realizarContratacaoViewModel))
                return null;

            var contratacao = _mapper.Map<Contratacao>(realizarContratacaoViewModel);
            
            await _contratacaoRepository.CriarAsync(contratacao, cancellationToken);
            
            return contratacao;
        }
        // mudar para estatico
        // simplificar realizarContratacaoViewModel.ValorDesconto > (realizarContratacaoViewModel.Quantidade * realizarContratacaoViewModel.ValorUnitario) 
        public bool ValidarDesconto(RealizarContratacaoViewModel realizarContratacaoViewModel)
        {
            var valorTotal = realizarContratacaoViewModel.Quantidade * realizarContratacaoViewModel.ValorUnitario;

            if (realizarContratacaoViewModel.ValorDesconto > valorTotal)
                return true;

            return false;
        }
        // tornar estatico, pode ser reaproveitado? se sim mover para um metodo de extensao
        public bool DiasUteis(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }
        // sempre que criar uma variavel mantenha o padrao com var
        // var horarioAtual
        public bool HorarioContratacao()
        {
            TimeSpan horarioAtual = DateTime.Now.TimeOfDay;

            TimeSpan inicio = new TimeSpan(10, 30, 0);
            TimeSpan fim = new TimeSpan(00, 59, 0);

            return horarioAtual >= inicio && horarioAtual <= fim;
        }
    }
}
