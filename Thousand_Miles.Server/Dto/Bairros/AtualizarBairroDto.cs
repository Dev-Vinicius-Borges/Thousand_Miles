
using Thousand_Miles.Server.Dto.Cidades;

namespace Thousand_Miles.Server.Dto.Bairros
{
    public class AtualizarBairroDto
    {
        public int id_bairro { get; set; }

        public required string nome_bairro { get; set; }

        public AtualizarCidadeDto cidade { get; set; }

    }
}
