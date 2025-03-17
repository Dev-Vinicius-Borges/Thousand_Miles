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
        public async Task<RespostaModel<EnderecoModel>> AtualizarEndereco(AtualizarEnderecoDto atualizarEnderecoDto)
        {
            RespostaModel<EnderecoModel> resposta = new RespostaModel<EnderecoModel>();
            using var transacao = await _contexto.Database.BeginTransactionAsync();
            try
            {
                EstadoModel? estado = await _contexto.Estados.FirstOrDefaultAsync(estado => estado.nome_estado == atualizarEnderecoDto.bairro.cidade.estado.nome_estado);
                if(estado == null)
                {
                    estado = new EstadoModel 
                    { 
                        nome_estado = atualizarEnderecoDto.bairro.cidade.estado.nome_estado,
                        sigla = atualizarEnderecoDto.bairro.cidade.estado.sigla
                    };

                    _contexto.Add(estado);
                    await _contexto.SaveChangesAsync();
                }

                CidadeModel? cidade = await _contexto.Cidades.FirstOrDefaultAsync(cidade => cidade.nome_cidade == atualizarEnderecoDto.bairro.cidade.nome_cidade);
                if (cidade == null)
                {
                    cidade = new CidadeModel
                    {
                        nome_cidade = atualizarEnderecoDto.bairro.cidade.nome_cidade,
                        estado = estado
                    };

                    _contexto.Add(cidade);
                    await _contexto.SaveChangesAsync();
                }

                BairroModel? bairro = await _contexto.Bairros.FirstOrDefaultAsync(bairro => bairro.nome_bairro == atualizarEnderecoDto.bairro.nome_bairro);
                if(bairro == null)
                {
                    bairro = new BairroModel
                    {
                        nome_bairro = atualizarEnderecoDto.bairro.nome_bairro,
                        cidade = cidade
                    };

                    _contexto.Add(bairro);
                    await _contexto.SaveChangesAsync();
                }

                EnderecoModel? endereco = await _contexto.Enderecos.FindAsync(atualizarEnderecoDto.id_endereco);
                if (endereco == null)
                {
                    endereco = new EnderecoModel
                    {
                        rua = atualizarEnderecoDto.rua,
                        numero = atualizarEnderecoDto.numero,
                        cep = atualizarEnderecoDto.cep,
                        bairro = bairro
                    };

                    _contexto.Add(endereco);
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    endereco.rua = atualizarEnderecoDto.rua;
                    endereco.numero = atualizarEnderecoDto.numero;
                    endereco.cep = atualizarEnderecoDto.cep;
                    endereco.bairro = bairro;

                    await _contexto.SaveChangesAsync();
                }

                int idUsuario = int.Parse(_httpContextAccessor.HttpContext?.Items["id_usuario"]?.ToString());
                Console.WriteLine($"ID encontrado: {idUsuario}");
                var usuario = await _contexto.Usuarios.FindAsync(idUsuario) ?? throw new ArgumentNullException();
                usuario.endereco = endereco;

                await _contexto.SaveChangesAsync();

                await transacao.CommitAsync();
                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Endereço atualizado.";
                return resposta;
            }
            catch (Exception err)
            {
                await transacao.RollbackAsync();
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }


    }
}
