
namespace ThousandMiles.Server.Dto.Usuarios
{
    public class RegistrarUsuarioDto
    {
        public required string email { get; set; }

        public required string senha { get; set; }

        public required byte status { get; set; }
    }
}
