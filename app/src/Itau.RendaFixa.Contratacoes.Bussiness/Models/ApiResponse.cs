namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    // este modelo deveria ser uma ViewModel eu acredito
    public class ApiResponse<T>
    {
        public T ?Data { get; set; }
    }
}
