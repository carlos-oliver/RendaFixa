using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public interface IHabilitarContratanteUseCase
    {
        Task<Contratante?> HabilitarContratante(HabilitarContratanteViewModel correcao, string cpf, CancellationToken cancellation = default);
    }
}
