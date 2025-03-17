using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Models.Veiculo;

namespace ThousandMiles.Server.Models.Usuarios
{
    public class VeiculosFavoritosModel
    {
        [Key]
        public int id_favoritos { get; set; }

        [JsonIgnore]
        public required UsuarioModel usuario { get; set; }

        [JsonIgnore]
        public required ModeloModel modelo { get; set; }
    }
}
