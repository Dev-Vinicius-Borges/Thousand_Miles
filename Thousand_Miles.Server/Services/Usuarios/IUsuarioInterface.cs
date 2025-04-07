using ThousandMiles.Server.Dto.Usuarios;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace ThousandMiles.Server.Services.Usuarios
{
    public interface IUsuarioInterface
    {
        Task<RespostaModel<UsuarioModel>> BuscarUsuarioPorEmail(string email);
        Task<RespostaModel<UsuarioModel>> RegistrarUsuario(RegistrarUsuarioDto registrarUsuarioDto);

        Task<RespostaModel<UsuarioModel>> LoginDeUsuario(LoginDeUsuarioDto loginDeUsuarioDto);

        Task<RespostaModel<UsuarioModel>> BuscarUsuarioProId(int id);

        Task<RespostaModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto);

        Task<RespostaModel<UsuarioModel>> DesativarConta(int id);
    }
}
