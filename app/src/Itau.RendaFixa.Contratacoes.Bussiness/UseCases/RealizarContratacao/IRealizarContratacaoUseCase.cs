using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public interface IRealizarContratacaoUseCase
    {
        Task<Contratacao> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default);
    }
}
