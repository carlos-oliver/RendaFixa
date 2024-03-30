﻿using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IConsultarProdutoUseCase _consultarProdutoUseCase;

        public ProdutoController(IConsultarProdutoUseCase consultarProdutoUseCase)
        {
            _consultarProdutoUseCase = consultarProdutoUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string? nome)
        {
            var produtos = await _consultarProdutoUseCase.ObterProdutoAsync(nome);
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Path()
        {
            throw new NotImplementedException();
        }
    }
}
