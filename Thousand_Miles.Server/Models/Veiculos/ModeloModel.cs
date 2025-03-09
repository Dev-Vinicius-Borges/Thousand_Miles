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
        public string nome_modelo { get; set; }

        [Column(TypeName = "tinyint")]
        public byte assentos { get; set; }

        public byte portas { get; set; }

        public string descricao_modelo { get; set; }

        [JsonIgnore]
        public MarcaModel marca { get; set; }

        [JsonIgnore]
        public CategoriaModel categoria { get; set; }

        [JsonIgnore]
        public CambioModel cambio { get; set; }

        [JsonIgnore]
        public CombustivelModel combustivel { get; set; }
    }
}
