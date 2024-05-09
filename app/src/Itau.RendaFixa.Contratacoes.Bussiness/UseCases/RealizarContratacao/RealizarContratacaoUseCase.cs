using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public class RealizarContratacaoUseCase : IRealizarContratacaoUseCase
    {
        private readonly IConsultarProdutoBloqueadoUseCase _consultarProdutoBloqueadoUseCase;
        private readonly IConsultarContratanteBloqueadoUseCase _consultarContratanteBloqueadoUseCase;
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public RealizarContratacaoUseCase(ContratacoesContext context, IMapper mapper, IConsultarProdutoBloqueadoUseCase consultarProdutoBloqueadoUseCase, IConsultarContratanteBloqueadoUseCase consultarContratanteBloqueado)
        {
            _context = context;
            _mapper = mapper;
            _consultarProdutoBloqueadoUseCase = consultarProdutoBloqueadoUseCase;
            _consultarContratanteBloqueadoUseCase = consultarContratanteBloqueado;
        }

        public async Task<Contratacao> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default)
        {


            if (DiasUteis(DateTime.Parse("2024-05-08")))
                return null;

            if (!HorarioContratacao())
                return null;

            if (await _consultarProdutoBloqueadoUseCase.ConsultarProduto(realizarContratacaoViewModel.IdProduto))
                return null;

            if (!await _consultarContratanteBloqueadoUseCase.ConsultarContratante(realizarContratacaoViewModel.IdContratante))
                return null;

            if (ValidarDesconto(realizarContratacaoViewModel))
                return null;

            Contratacao contratacao = _mapper.Map<Contratacao>(realizarContratacaoViewModel);
            await _context.Contratacoes.AddAsync(contratacao, cancellationToken);
            _context.SaveChanges();
            return contratacao;
        }

        public bool ValidarDesconto(RealizarContratacaoViewModel realizarContratacaoViewModel)
        {
            var valorTotal = realizarContratacaoViewModel.Quantidade * realizarContratacaoViewModel.ValorUnitario;

            if (realizarContratacaoViewModel.ValorDesconto > valorTotal)
                return true;

            return false;
        }

        public bool DiasUteis(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }

        public bool HorarioContratacao()
        {
            TimeSpan horarioAtual = DateTime.Now.TimeOfDay;

            TimeSpan inicio = new TimeSpan(10, 30, 0);
            TimeSpan fim = new TimeSpan(23, 59, 0);

            return horarioAtual >= inicio && horarioAtual <= fim;
        }
    }
}
