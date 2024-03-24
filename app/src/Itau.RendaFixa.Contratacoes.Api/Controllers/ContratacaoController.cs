using Microsoft.AspNetCore.Mvc;

namespace Itau.RendaFixa.Contratacoes.Api.Controllers
{
    [ApiController]
    [Route("cotratacoes")]
    public class ContratacaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            throw new NotImplementedException();
        }

    }
}
