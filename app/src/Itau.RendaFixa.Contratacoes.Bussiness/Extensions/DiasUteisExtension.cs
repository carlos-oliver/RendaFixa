namespace Itau.RendaFixa.Contratacoes.Bussiness.Extensions
{
    public static class DiasUteisExtension
    {
        public static bool DiasUteis(this DateTime data)
        {
            return data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
