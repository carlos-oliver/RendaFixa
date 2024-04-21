using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto
{
    public interface IAlterarProdutoUseCase
    {
        Task<AlterarProdutoViewModel> AlterarNomeProduto(JsonPatchDocument<AlterarProdutoViewModel> patch, int id);
    }
}
