using AutoMapper;
using Itau.RendaFixa.Contratacoes.Api.Data;
using Itau.RendaFixa.Contratacoes.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private ContratacoesContext _context;
        private IMapper _mapper;

        public TipoProdutoController(ContratacoesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RecuperarTipoP()
        {
            var tipoProdutos = _context.TipoProdutos.ToList();
            var tipoProdutosDto = _mapper.Map<List<TipoProduto>>(tipoProdutos);

            var response = new ApiResponse<List<TipoProduto>>
            {
                Data = tipoProdutosDto
            };
            if (tipoProdutosDto.Count == 0 ) { return NoContent(); };
            return Ok(response);
        }

    }
}
