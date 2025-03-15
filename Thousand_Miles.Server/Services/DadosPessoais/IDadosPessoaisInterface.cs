using Thousand_Miles.Server.Dto.DadosPessoais;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace Thousand_Miles.Server.Services.DadosPessoais
{
    public interface IDadosPessoaisInterface
    {
        Task<RespostaModel<DadosPessoaisModel>> CriarDadosPessoais(CriarDadosPessoaisDto criarDadosPessoaisDto);

        Task<RespostaModel<DadosPessoaisModel>> AtualizarDadosPessoais(AtualizarDadosPessoaisDto atualizarDadosPessoaisDto);
    }
}
