using Thousand_Miles.Server.Dto.Enderecos;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Models;

namespace Thousand_Miles.Server.Services.Enderecos
{
    public interface IEnderecoInterface
    {
        Task<RespostaModel<EnderecoModel>> CriarEndereco(CriarEnderecoDto criarEnderecoDto);
        Task<RespostaModel<List<EnderecoModel>>> BuscarEnderecoPorNomeDaRua(string nomeDaRua);
        Task<RespostaModel<List<EnderecoModel>>> BuscarEnderecoPorCEP(string cep);
        Task<RespostaModel<EnderecoModel>> AtualizarEndereco(AtualizarEnderecoDto atualizarEnderecoDto);
        Task<RespostaModel<EnderecoModel>> DesativarEndereco(int idEndereco);
    }
}
