using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class ModeloModel
    {
        [Key]
        public int id_modelo { get; set; }

        [Column(TypeName = "varchar(45)")]
        public required string nome_modelo { get; set; }

        [Column(TypeName = "tinyint")]
        public required byte assentos { get; set; }

        public required byte portas { get; set; }

        public required string descricao_modelo { get; set; }

        [JsonIgnore]
        public required MarcaModel marca { get; set; }

        [JsonIgnore]
        public required CategoriaModel categoria { get; set; }

        [JsonIgnore]
        public required CambioModel cambio { get; set; }

        [JsonIgnore]
        public required CombustivelModel combustivel { get; set; }
    }
}
