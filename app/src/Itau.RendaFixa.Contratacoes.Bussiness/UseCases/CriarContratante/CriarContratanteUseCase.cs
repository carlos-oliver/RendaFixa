using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante
{
    public class CriarContratanteUseCase : ICriarContratanteUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public CriarContratanteUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Contratante> CriarContratante(CriarContratanteViewModel criarContranteViewModel, CancellationToken cancellationToken = default)
        {
            Contratante contratante = _mapper.Map<Contratante>(criarContranteViewModel);
            await _context.Contratantes.AddAsync(contratante, cancellationToken);
            _context.SaveChanges();
            return contratante;
        }
    }
}
