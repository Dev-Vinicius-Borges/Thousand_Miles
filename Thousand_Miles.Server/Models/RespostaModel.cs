namespace ThousandMiles.Server.Models
{
    public class RespostaModel<T>
    {
        public T? Dados { get; set; }
        public int Status { get; set; }
        public string? Mensagem { get; set; }
    
        public string? Token { get; set; }
    }
}
