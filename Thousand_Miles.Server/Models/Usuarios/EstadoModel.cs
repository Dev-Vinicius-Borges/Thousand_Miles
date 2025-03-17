using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class EstadoModel
    {
        [Key]
        public int id_estado { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string nome_estado { get; set; }

        [Column(TypeName = "varchar(3)")]
        public required string sigla { get; set; }

    }
}
