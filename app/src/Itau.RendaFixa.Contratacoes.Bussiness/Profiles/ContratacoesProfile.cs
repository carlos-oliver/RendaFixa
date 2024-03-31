using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Profiles
{
    public class ContratacoesProfile : Profile
    {
        public ContratacoesProfile()
        {
            CreateMap<TipoProduto, TipoProdutoDto>();
            CreateMap<Produtos, ProdutosDto>();
        }
    }
}
