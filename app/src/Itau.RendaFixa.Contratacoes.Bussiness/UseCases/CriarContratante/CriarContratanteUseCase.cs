using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante
{
    public class CriarContratanteUseCase : ICriarContratanteUseCase
    {
        private readonly ICriarContratanteRepository _criarContratanteRepository;
        private readonly IConsultarContratanteRepository _consultarContratanteRepository;
        private readonly IMapper _mapper;

        public CriarContratanteUseCase(ICriarContratanteRepository criarContratanteRepository,
            IConsultarContratanteRepository consultarContratanteRepository,
            IMapper mapper)
        {
            _criarContratanteRepository = criarContratanteRepository;
            _consultarContratanteRepository = consultarContratanteRepository;
            _mapper = mapper;
        }

        public async Task<bool> ValidaNomeExistente(string nome, CancellationToken cancellationToken = default)
        {
            var contratantes = await _consultarContratanteRepository.ConsultarContratantesAsync(cancellationToken);
            return contratantes.Any(x => x.Nome == nome);      
        }

        public async Task<Contratante?> CriarContratante(CriarContratanteViewModel criarContranteViewModel, CancellationToken cancellationToken = default)
        {
            if (await ValidaNomeExistente(criarContranteViewModel.Nome))
                return default;
            var contratante = _mapper.Map<Contratante>(criarContranteViewModel);
            await _criarContratanteRepository.Criar(contratante, cancellationToken);

            return contratante;
        }
    }
}
