﻿using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public class AtualizarContratacaoUseCase : IAtualizarContratacaoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;

        public AtualizarContratacaoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RealizarContratacaoViewModel> Consultarcontratacao(int idContratante, int idProduto, DateOnly dataOperacao, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratacoes.AsQueryable();

            var contratacao = await query.Where(x => 
                x.IdContratante == idContratante && 
                x.IdProduto == idProduto && 
                DateOnly.FromDateTime(x.DataOperacao) == dataOperacao)
                .FirstOrDefaultAsync(cancellationToken);

            var contratacaoModel = _mapper.Map<RealizarContratacaoViewModel>(contratacao);

            return contratacaoModel;
        }

        public async Task AtualizarContratacao(RealizarContratacaoViewModel contratacao, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratacoes.AsQueryable();

            var contratacaoQuery = await query.Where(x =>
                x.IdContratante == contratacao.Id_Contratante &&
                x.IdProduto == contratacao.Id_Produto &&
                x.DataOperacao == contratacao.Data_Operacao)
                .FirstOrDefaultAsync(cancellationToken);

            contratacaoQuery.Quantidade += contratacao.Quantidade;
            contratacaoQuery.ValorUnitario += contratacao.Valor_Unitario;

            _context.Contratacoes.Update(contratacaoQuery);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
