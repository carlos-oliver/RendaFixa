using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public class RealizarContratacaoUseCase : IRealizarContratacaoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public RealizarContratacaoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Contratacao> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default)
        {
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
    }
}
