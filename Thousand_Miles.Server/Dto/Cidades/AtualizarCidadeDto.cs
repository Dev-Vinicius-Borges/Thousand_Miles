
using Thousand_Miles.Server.Dto.Estados;

namespace Thousand_Miles.Server.Dto.Cidades
{
    public class AtualizarCidadeDto
    {
        public int id_cidade { get; set; }

        public required string nome_cidade { get; set; }

        public AtualizarEstadosDto estado { get; set; }

    }
}
