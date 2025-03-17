using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Reservas
{
    public class SeguroModel
    {
        [Key]
        public int Id_seguro { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string tipo_seguro { get; set; }

        public required string descricao { get; set; }

        public required float custo { get; set; }
    }
}
