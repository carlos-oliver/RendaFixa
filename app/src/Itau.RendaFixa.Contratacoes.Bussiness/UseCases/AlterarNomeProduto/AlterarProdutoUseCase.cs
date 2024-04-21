using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

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

        public async Task<AlterarProdutoViewModel> AlterarNomeProduto(JsonPatchDocument<AlterarProdutoViewModel> patch, int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return null;
            }

            var produtoViewModel = _mapper.Map<AlterarProdutoViewModel>(produto);

            patch.ApplyTo(produtoViewModel);

            _mapper.Map(produtoViewModel, produto);

            await _context.SaveChangesAsync();

            return produtoViewModel;
        }
    }
}
