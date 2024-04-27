using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public class HabilitarContratanteUseCase : IHabilitarContratanteUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public HabilitarContratanteUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HabilitarContratanteViewModel> HabilitarContratante(JsonPatchDocument<HabilitarContratanteViewModel> correcao, string cpf, CancellationToken cancellationToken)
        {
            var query = _context.Contratantes.AsQueryable();

            var contrante = await query.Where(x => x.Cpf == cpf).FirstOrDefaultAsync(cancellationToken);

            if (contrante == null)
                return null;

            var contratanteViewModel = _mapper.Map<HabilitarContratanteViewModel>(contrante);

            correcao.ApplyTo(contratanteViewModel);

            _mapper.Map(contratanteViewModel, contrante);

            await _context.SaveChangesAsync();

            return contratanteViewModel;
        }
    }
}
