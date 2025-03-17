using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class UsuarioModel
    {
        [Key]
        public int id_usuario { get; set; }

        public required string email { get; set; }

        public required string senha { get; set; }

        public required bool status { get; set; }

        [JsonIgnore]
        public DadosPessoaisModel? dados_pessoais { get; set; }

        [JsonIgnore]
        public EnderecoModel? endereco { get; set; }
    }
}
