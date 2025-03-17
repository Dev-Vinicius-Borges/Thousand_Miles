
namespace Thousand_Miles.Server.Dto.Estados
{
    public class AtualizarEstadosDto
    {
        public int id_estado { get; set; }

        public required string nome_estado { get; set; }
        public required string sigla { get; set; }
    }
}
