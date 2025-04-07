using Microsoft.EntityFrameworkCore;
using Thousand_Miles.Server.Dto.Enderecos;
using ThousandMiles.Server.Database;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace Thousand_Miles.Server.Services.Enderecos
{
    public class EnderecoService : IEnderecoInterface
    {
        private readonly AppDbContext _contexto;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EnderecoService(AppDbContext contexto, IHttpContextAccessor httpContextAccessor)
        {
            _contexto = contexto;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RespostaModel<EnderecoModel>> AtualizarEndereco(AtualizarEnderecoDto atualizarEnderecoDto, BairroModel bairro)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            try
            {
                var endereco = await _contexto.Enderecos.SingleOrDefaultAsync(endereco => endereco.id_endereco == atualizarEnderecoDto.id_endereco);
                if (endereco == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Endereço não encontrado.";
                    return resposta;
                }

                endereco.rua = atualizarEnderecoDto.rua;
                endereco.numero = atualizarEnderecoDto.numero;
                endereco.cep = atualizarEnderecoDto.cep;
                endereco.bairro = bairro;

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Endereço atualizado.";
                resposta.Dados = endereco;

                return resposta;

            }catch(Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public Task<RespostaModel<List<EnderecoModel>>> BuscarEnderecoPorNomeDaRua(string nomeDaRua)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaModel<EnderecoModel>> CriarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaModel<EnderecoModel>> DesativarEndereco(int idEndereco)
        {
            throw new NotImplementedException();
        }
    }
}
