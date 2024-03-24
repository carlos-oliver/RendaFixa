using AutoMapper;
using Itau.RendaFixa.Contratacoes.Api.Data.Dtos;
using Itau.RendaFixa.Contratacoes.Api.ViewModels;

namespace Itau.RendaFixa.Contratacoes.Api.Profiles
{
    public class ContratacoesProfile : Profile
    {
        public ContratacoesProfile() 
        {
            CreateMap<TipoProdutoDto, TipoProduto>();
        }
    }
}
