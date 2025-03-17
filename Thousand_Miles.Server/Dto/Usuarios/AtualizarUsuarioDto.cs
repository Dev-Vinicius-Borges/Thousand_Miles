namespace ThousandMiles.Server.Dto.Usuarios
{
    public class AtualizarUsuarioDto
    {
        public required int id { get; set; }
        public required string email { get; set; }
        public required string senha { get; set; }

    }
}
