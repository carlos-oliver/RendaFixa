using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using System.Net;

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
        // Duvida: Queria atualizar apenas um campo por isso usei, troquei por um metodo comum
        public async Task<(HttpStatusCode, DefaultResultViewModel<Contratante>)> HabilitarContratante(HabilitarContratanteViewModel atualiza, string cpf, CancellationToken cancellationToken = default)
        {
            var query = await _consultarContratanteRepository.ConsultarContratantesAsync(cancellationToken);

            var contratante = query.FirstOrDefault(x => x.Cpf == cpf);
            if (contratante is null)
            {
                var erros = new List<Notification>
                {
                    new Notification(NotificationLevel.Information, "001","Contratante não encontrado")
                };
                return (HttpStatusCode.NotFound, new DefaultResultViewModel<Contratante>(erros));
            }

            contratante.Habilitado = atualiza.Habilitado;
            await _habilitarContratanteRepository.HabilitarAsync(contratante, cancellationToken);

            return (HttpStatusCode.Accepted, new DefaultResultViewModel<Contratante>(contratante));
        }
    }
}
