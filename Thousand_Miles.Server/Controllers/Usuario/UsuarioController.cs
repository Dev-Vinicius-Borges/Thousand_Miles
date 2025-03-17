using Microsoft.AspNetCore.Mvc;
using ThousandMiles.Server.Dto.Usuarios;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Services.Usuarios;

namespace Thousand_Miles.Server.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<RespostaModel<UsuarioModel>>> RegistrarUsuario(RegistrarUsuarioDto registrarUsuarioDto)
        {
            var registro = await _usuarioInterface.RegistrarUsuario(registrarUsuarioDto);
            return Ok(registro);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<RespostaModel<UsuarioModel>>> LoginDeUsuario(LoginDeUsuarioDto loginDeUsuarioDto)
        {
            var login = await _usuarioInterface.LoginDeUsuario(loginDeUsuarioDto);
            return Ok(login);
        }

        [HttpGet("Gerenciador")]
        public bool Test()
        {
            return true;
        }
    }
}
