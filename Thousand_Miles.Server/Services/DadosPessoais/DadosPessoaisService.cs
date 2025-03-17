using Microsoft.EntityFrameworkCore;
using Thousand_Miles.Server.Dto.DadosPessoais;
using ThousandMiles.Server.Database;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace Thousand_Miles.Server.Services.DadosPessoais
{
    public class DadosPessoaisService : IDadosPessoaisInterface
    {
        private readonly AppDbContext _context;
        public DadosPessoaisService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<RespostaModel<DadosPessoaisModel>> AtualizarDadosPessoais(AtualizarDadosPessoaisDto atualizarDadosPessoaisDto)
        {
            RespostaModel<DadosPessoaisModel> resposta = new RespostaModel<DadosPessoaisModel>();
            try
            {
                DadosPessoaisModel? dadoPessoal = await _context.DadosPessoais.SingleOrDefaultAsync(dados => dados.id_dados_pessoais == atualizarDadosPessoaisDto.id);

                if(dadoPessoal == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Erro ao buscar os dados pessoais.";
                    return resposta;
                }

                dadoPessoal.genero = atualizarDadosPessoaisDto.genero;
                dadoPessoal.sobrenome = atualizarDadosPessoaisDto.sobrenome;
                dadoPessoal.nome = atualizarDadosPessoaisDto.nome;

                await _context.SaveChangesAsync();

                resposta.Mensagem = "Dados pessoais atualizados.";
                resposta.Status = StatusCodes.Status200OK;
                resposta.Dados = dadoPessoal;

                return resposta;
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }

        }

        public async Task<RespostaModel<DadosPessoaisModel>> CriarDadosPessoais(CriarDadosPessoaisDto criarDadosPessoaisDto)
        {
            RespostaModel<DadosPessoaisModel> resposta = new RespostaModel<DadosPessoaisModel>();
            try
            {
                DadosPessoaisModel novosDados = new DadosPessoaisModel
                {
                    nome = criarDadosPessoaisDto.nome,
                    sobrenome = criarDadosPessoaisDto.sobrenome,
                    data_nascimento = criarDadosPessoaisDto.data_nascimento,
                    genero = criarDadosPessoaisDto.genero
                };

                _context.Add(novosDados);

                await _context.SaveChangesAsync();

                resposta.Status = StatusCodes.Status201Created;
                resposta.Dados = novosDados;
                resposta.Mensagem = "Dados pessoais criados.";

                return resposta;

            }catch (Exception err){
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }
    }
}
