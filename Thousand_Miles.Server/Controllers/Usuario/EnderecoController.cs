using Microsoft.AspNetCore.Mvc;
using Thousand_Miles.Server.Dto.Enderecos;
using Thousand_Miles.Server.Services.Enderecos;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace Thousand_Miles.Server.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoInterface _enderecoInterface;
        public EnderecoController(IEnderecoInterface enderecoInterface)
        {
            _enderecoInterface = enderecoInterface;
        }

        [HttpPost("Gerenciador/Atualizar")]
        public async Task<ActionResult<RespostaModel<EnderecoModel>>> AtualizarEndereco(AtualizarEnderecoDto atualizarEnderecoDto)
        {
            var atualizacao = await _enderecoInterface.AtualizarEndereco(atualizarEnderecoDto);
            return Ok(atualizacao);
        }
    }
}
