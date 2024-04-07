using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Profiles
{
    public class ContratacoesProfile : Profile
    {
        public ContratacoesProfile()
        {
            CreateMap<TipoProduto, TipoProdutoViewModel>();
            CreateMap<Produto, ProdutosDto>();
            CreateMap<CriarProdutoDto, Produto>();
        }
    }
}
