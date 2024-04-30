﻿using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante.ViewModels;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Profiles
{
    public class ContratacoesProfile : Profile
    {
        public ContratacoesProfile()
        {
            CreateMap<TipoProduto, TipoProdutoViewModel>();
            CreateMap<Produto, ConsultarProdutoViewModel>();
            CreateMap<CriarProdutoViewModel, Produto>();
            CreateMap<AlterarProdutoViewModel, Produto>();
            CreateMap<Produto, AlterarProdutoViewModel>();
            CreateMap<CriarContratanteViewModel, Contratante>();
            CreateMap<HabilitarContratanteViewModel, Contratante>();
            CreateMap<Contratante, HabilitarContratanteViewModel>();
            CreateMap<RealizarContratacaoViewModel, Contratacao>();
            CreateMap<Contratacao, RealizarContratacaoViewModel>();
            //CreateMap<AlterarContratacaoViewModel, Contratacao>();
        }
    }
}
