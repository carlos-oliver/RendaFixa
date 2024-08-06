using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public interface IHabilitarContratanteUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<Contratante>)> HabilitarContratante(HabilitarContratanteViewModel correcao, string cpf, CancellationToken cancellation = default);
    }
}
