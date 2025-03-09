using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class BairroModel
    {
        [Key]
        public int id_bairro { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string nome_bairro { get; set; }

        [JsonIgnore]
        public CidadeModel cidade { get; set; }
    }
}
