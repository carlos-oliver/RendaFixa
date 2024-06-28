using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using System.Web.Http.OData;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public class HabilitarContratanteUseCase : IHabilitarContratanteUseCase
    {
        private readonly IContratacaoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConsultarContratanteRepository _consultarContratanteRepository;
        private readonly IHabilitarContratanteRepository _habilitarContratanteRepository;

        public HabilitarContratanteUseCase(IContratacaoDbContext context,
            IConsultarContratanteRepository consultarContratanteRepository,
            IHabilitarContratanteRepository habilitarContratanteRepository,
            IMapper mapper)
        {
            _consultarContratanteRepository = consultarContratanteRepository;
            _habilitarContratanteRepository = habilitarContratanteRepository;
            _context = context;
            _mapper = mapper;
        }
        // aqui nao entendi o uso de JsonPatchDocument, pode explicar?
        // Duvida: Queria atualizar apenas um campo por isso usei, troquei pelo "Delta"
        public async Task<HabilitarContratanteViewModel?> HabilitarContratante(Delta<HabilitarContratanteViewModel> atualiza, string cpf, CancellationToken cancellationToken = default)
        {
            var query = await _consultarContratanteRepository.ConsultarContratantesAsync(cancellationToken);

            var contratante = query.FirstOrDefault(x => x.Cpf == cpf);
            if (contratante is null)
                return default;

            var contratanteViewModel = _mapper.Map<HabilitarContratanteViewModel>(contratante);

            atualiza.Patch(contratanteViewModel);
            _mapper.Map(contratanteViewModel, contratante);
            await _habilitarContratanteRepository.HabilitarAsync(contratante, cancellationToken);

           return contratanteViewModel;
        }
    }
}
