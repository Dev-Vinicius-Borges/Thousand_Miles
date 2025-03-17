using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class CambioModel
    {
        [Key]
        public int id_cambio { get; set; }

        [Column(TypeName = "varchar(45)")]
        public required string nome_cambio { get; set; }

    }
}
