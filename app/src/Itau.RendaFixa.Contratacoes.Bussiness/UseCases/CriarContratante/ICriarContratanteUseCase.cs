using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante
{
    public interface ICriarContratanteUseCase
    {
        Task<(HttpStatusCode, DefaultResultViewModel<Contratante>)> CriarContratante(CriarContratanteViewModel criarContranteViewModel, CancellationToken cancellationToken = default);
    }
}
