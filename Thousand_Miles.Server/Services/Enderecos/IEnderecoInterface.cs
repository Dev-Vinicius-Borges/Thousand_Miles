using Thousand_Miles.Server.Dto.Enderecos;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Models;

namespace Thousand_Miles.Server.Services.Enderecos
{
    public interface IEnderecoInterface
    {
        Task<RespostaModel<EnderecoModel>> AtualizarEndereco(AtualizarEnderecoDto atualizarEnderecoDto);
    }
}
