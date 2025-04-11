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
            RespostaModel<List<EnderecoModel>> resposta = new RespostaModel<List<EnderecoModel>>();
            try
            {
                var enderecos = _contexto.Enderecos.Where(endereco => endereco.rua.Contains(nomeDaRua)).ToListAsync();
                if (enderecos == null || !enderecos.Result.Any())
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Nenhum endereço encontrado.";
                    return Task.FromResult(resposta);
                }

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Endereços encontrados.";
                resposta.Dados = enderecos.Result;

                return Task.FromResult(resposta);
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return Task.FromResult(resposta);
            }
        }

        public Task<RespostaModel<EnderecoModel>> CriarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            try
            {
                var endereco = new EnderecoModel
                {
                    rua = criarEnderecoDto.rua,
                    numero = criarEnderecoDto.numero,
                    cep = criarEnderecoDto.cep,
                    bairro = criarEnderecoDto.bairro
                };

                _contexto.Enderecos.Add(endereco);
                _contexto.SaveChanges();

                resposta.Status = StatusCodes.Status201Created;
                resposta.Mensagem = "Endereço criado com sucesso.";
                resposta.Dados = endereco;

                return Task.FromResult(resposta);
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return Task.FromResult(resposta);
            }
        }

        public Task<RespostaModel<EnderecoModel>> DesativarEndereco(int idEndereco)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            try
            {
                var endereco = _contexto.Enderecos.SingleOrDefaultAsync(endereco => endereco.id_endereco == idEndereco);
                if (endereco == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Endereço não encontrado.";
                    return resposta;
                }

                _contexto.Enderecos.Remove(endereco.Result);
                _contexto.SaveChanges();

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Endereço desativado com sucesso.";
                resposta.Dados = endereco.Result;

                return resposta;
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }
    }
}
