using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao
{
    public interface IConsultarContratanteBloqueadoUseCase
    {
        Task<bool> ConsultarContratante(int idContratante, CancellationToken cancellationToken = default);
    }
}
