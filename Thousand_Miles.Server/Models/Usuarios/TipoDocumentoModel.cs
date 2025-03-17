using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Usuario
{
    public class TipoDocumentoModel
    {
        [Key]
        public int id_tipo_documento { get; set; }

        [Column(TypeName = "varchar(20)")]
        public required string tipo_documento { get; set; }

    }
}
