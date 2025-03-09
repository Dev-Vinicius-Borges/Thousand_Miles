namespace ThousandMiles.Server.Models
{
    public class RespostaModel<T>
    {
        public T? Dados { get; set; }
        public int status { get; set; }
        public string Mensagem { get; set; }
    
        public string? Token { get; set; }
    }
}
