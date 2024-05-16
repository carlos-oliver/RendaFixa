﻿using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Microsoft.AspNetCore.JsonPatch;


namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante
{
    public class HabilitarContratanteUseCase : IHabilitarContratanteUseCase
    {
        private readonly IContratacaoDbContext _context;
        private readonly IMapper _mapper;

        public HabilitarContratanteUseCase(IContratacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // aqui nao entendi o uso de JsonPatchDocument, pode explicar?
        public async Task<HabilitarContratanteViewModel> HabilitarContratante(JsonPatchDocument<HabilitarContratanteViewModel> patch, string cpf, CancellationToken cancellationToken)
        {
            var query = _context.Contratantes.AsQueryable();

            //var contrante = await query.Where(x => x.Cpf == cpf).FirstOrDefaultAsync(cancellationToken);
            //// alterar para contratante is null para melhorar legibilidade
            //if (contrante == null)
            //    return null;
//
            //var contratanteViewModel = _mapper.Map<HabilitarContratanteViewModel>(contrante);
//
            //patch.ApplyTo(contratanteViewModel);
//
            //_mapper.Map(contratanteViewModel, contrante);
//
            //await _context.SaveChangesAsync();

            return default;
        }
    }
}
