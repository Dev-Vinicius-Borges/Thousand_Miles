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
        public Task<RespostaModel<DadosPessoaisModel>> AtualizarDadosPessoais(AtualizarDadosPessoaisDto atualizarDadosPessoaisDto)
        {
            RespostaModel<DadosPessoaisModel> resposta = new RespostaModel<DadosPessoaisModel>();

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

                resposta.status = StatusCodes.Status201Created;
                resposta.Dados = novosDados;
                resposta.Mensagem = "Dados pessoais criados.";

                return resposta;

            }catch (Exception err){
                resposta.status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }
    }
}
