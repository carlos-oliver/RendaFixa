using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = new
            {
                error = new[]
                {
                    new
                    {
                        code = "APPERRORCODE0000",
                        nome = "Ocorreu um erro inesperado",
                        erro = exception.Message
                    }
                }
            };
            // estes if/else sao iguais
            
            context.Result = new ObjectResult(response)
            {
                StatusCode = 500
            };
            

            context.ExceptionHandled = true;
        }
    }
}
