using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public interface IRealizarContratacaoUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<Contratacao>)> RealizarContratacao(RealizarContratacaoViewModel realizarContratacaoViewModel, CancellationToken cancellationToken = default);
    }
}
