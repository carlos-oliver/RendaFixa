using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Itau.RendaFixa.Contratacoes.Infrastructure.Data.Dtos;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Profiles
{
    public class ContratacoesProfile : Profile
    {
        public ContratacoesProfile()
        {
            CreateMap<TipoProdutoDto, TipoProduto>();
        }
    }
}
