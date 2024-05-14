using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public class AlterarProdutoUseCase : IAlterarProdutoUseCase
    {
        private readonly ContratacoesContext _context;
        private readonly IMapper _mapper;
        public AlterarProdutoUseCase(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AlterarProdutoViewModel> AlterarNomeProduto(JsonPatchDocument<AlterarProdutoViewModel> patch, int id, CancellationToken cancellationToken)
        {
            var query = _context.Produtos.AsQueryable();
            // caso voce nao encontre o produto precisa garantir que o cliente receber um 404
            // implementar um notification
            var produto = await query.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

            if (produto == null)
                return null;
            // simplificar o processo de mapping
            var produtoViewModel = _mapper.Map<AlterarProdutoViewModel>(produto);

            patch.ApplyTo(produtoViewModel);

            _mapper.Map(produtoViewModel, produto);

            await _context.SaveChangesAsync();

            return produtoViewModel;
        }
    }
}
