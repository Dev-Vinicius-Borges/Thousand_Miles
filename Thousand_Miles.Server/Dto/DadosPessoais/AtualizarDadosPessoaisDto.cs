using System.ComponentModel.DataAnnotations.Schema;

namespace Thousand_Miles.Server.Dto.DadosPessoais
{
    public class AtualizarDadosPessoaisDto
    {
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public DateTime data_nascimento { get; set; }

        public string genero { get; set; }
    }
}
