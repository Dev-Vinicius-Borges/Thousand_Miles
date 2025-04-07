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

            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<List<EnderecoModel>>> BuscarEnderecoPorNomeDaRua(string nomeDaRua)
        {
            RespostaModel<List<EnderecoModel>> resposta = new RespostaModel<List<EnderecoModel>>();
            try
            {
                var enderecos = await _contexto.Enderecos.Where(endereco => endereco.rua.Contains(nomeDaRua)).ToListAsync();

                if (enderecos.Count < 1)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Endereço não encontrado.";
                    return resposta;
                }

                resposta.Dados = enderecos;
                resposta.Status = StatusCodes.Status302Found;
                resposta.Mensagem = "Endereços encontrados.";

                return resposta;

            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<EnderecoModel>> CriarEndereco(CriarEnderecoDto criarEnderecoDto, BairroModel bairro)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            try
            {
                var endereco = await _contexto.Enderecos
                    .Join(
                        _contexto.Bairros,
                        end => end.bairro.id_bairro,
                        bair => bair.id_bairro,
                        (end, bair) => new EnderecoModel
                        {
                            id_endereco = end.id_endereco,
                            rua = end.rua,
                            cep = end.cep,
                            bairro = bair,
                            numero = end.numero,
                            status = true
                        }
                    ).Where(end => end.rua == criarEnderecoDto.rua && end.cep == criarEnderecoDto.cep).FirstAsync();

                if (endereco == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Esse endereço já existe";
                }

                resposta.Status = StatusCodes.Status302Found;
                resposta.Mensagem = "Endereço(os) encontrado(os).";
                resposta.Dados = endereco;

            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor {err.Message}";
            }
            return resposta;
        }

        public async Task<RespostaModel<EnderecoModel>> DesativarEndereco(int idEndereco)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            try
            {
                var endereco = await _contexto.Enderecos.FindAsync(idEndereco);

                if (endereco == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Endereço não encontrado.";
                }

                endereco.status = false;

                await _contexto.SaveChangesAsync();

                resposta.Status = StatusCodes.Status205ResetContent;
                resposta.Mensagem = "Endereço atualizado";
                resposta.Dados = endereco;

            } catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
            }
            return resposta;
        }
    }
}
