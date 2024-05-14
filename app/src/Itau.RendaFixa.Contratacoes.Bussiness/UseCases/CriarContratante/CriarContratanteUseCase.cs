using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante
{
    public class CriarContratanteUseCase : ICriarContratanteUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public CriarContratanteUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ValidaNomeExistente(string nome)
        {
            return await _context.Contratantes.AnyAsync(x => x.Nome == nome);
        }
        // se o seu metodo pode retornar nulo, voce precisa indicar isso com o sufixo ?
        // veja exemplo: Task<Contratante?> CriarContratante
        public async Task<Contratante> CriarContratante(CriarContratanteViewModel criarContranteViewModel, CancellationToken cancellationToken = default)
        {
            // ao inves de retornar o null prefica o default
            if (await ValidaNomeExistente(criarContranteViewModel.Nome))
                return null;
            
            Contratante contratante = _mapper.Map<Contratante>(criarContranteViewModel);
            // mover a logica de manipular conexoes com banco operacoes com banco, chamadas http para uma camada especific
            // atendendo o principio de responsabilidade unica
            await _context.Contratantes.AddAsync(contratante, cancellationToken);
            _context.SaveChanges();
            return contratante;
        }
    }
}
