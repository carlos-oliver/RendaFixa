using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public class HabilitarContratanteUseCase : IHabilitarContratanteUseCase
    {
        private readonly IConsultarContratanteRepository _consultarContratanteRepository;
        private readonly IHabilitarContratanteRepository _habilitarContratanteRepository;

        public HabilitarContratanteUseCase(
            IConsultarContratanteRepository consultarContratanteRepository,
            IHabilitarContratanteRepository habilitarContratanteRepository)
        {
            _consultarContratanteRepository = consultarContratanteRepository;
            _habilitarContratanteRepository = habilitarContratanteRepository;
        }
        // aqui nao entendi o uso de JsonPatchDocument, pode explicar?
        // Duvida: Queria atualizar apenas um campo por isso usei, troquei pelo "Delta"
        public async Task<Contratante?> HabilitarContratante(HabilitarContratanteViewModel atualiza, string cpf, CancellationToken cancellationToken = default)
        {
            var query = await _consultarContratanteRepository.ConsultarContratantesAsync(cancellationToken);

            var contratante = query.FirstOrDefault(x => x.Cpf == cpf);
            if (contratante is null)
                return default;

            contratante.Habilitado = atualiza.Habilitado;
            await _habilitarContratanteRepository.HabilitarAsync(contratante, cancellationToken);

           return contratante;
        }
    }
}
