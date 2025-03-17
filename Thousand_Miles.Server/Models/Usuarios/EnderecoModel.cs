using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class EnderecoModel
    {
        [Key]
        public int id_endereco { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string rua { get; set; }

        [Column(TypeName = "varchar(10)")]
        public required string numero { get; set; }

        [Column(TypeName = "varchar(11)")]
        public required string cep { get; set; }

        public required BairroModel bairro { get; set; }
    }
}
