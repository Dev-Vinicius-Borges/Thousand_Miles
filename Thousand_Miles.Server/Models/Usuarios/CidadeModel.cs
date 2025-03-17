using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class CidadeModel
    {
        [Key]
        public int id_cidade { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string nome_cidade { get; set; }

        public required EstadoModel estado { get; set; }

    }
}
