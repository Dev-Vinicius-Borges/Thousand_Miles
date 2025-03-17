using System.ComponentModel.DataAnnotations.Schema;

namespace Thousand_Miles.Server.Dto.DadosPessoais
{
    public class CriarDadosPessoaisDto
    {
        public required string nome { get; set; }

        public required string sobrenome { get; set; }

        public required DateTime data_nascimento { get; set; }

        public required string genero { get; set; }
    }
}
