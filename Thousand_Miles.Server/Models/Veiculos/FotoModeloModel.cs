using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class FotoModeloModel
    {
        [Key]
        public int id_foto_modelo { get; set; }

        public required string url_modelo { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string tipo_conteudo { get; set; }

        [JsonIgnore]
        public required CoresModel cor { get; set; }

        [JsonIgnore]
        public required ModeloModel modelo { get; set; }
    }
}
