using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto
{
    public interface ICriarProdutoUseCase
    {
        Task<Produto> CriarProduto(CriarProdutoViewModel criarProdutoViewModel, CancellationToken cancellationToken = default);
    }
}
